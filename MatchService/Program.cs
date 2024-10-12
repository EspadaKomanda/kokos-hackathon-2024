using System.Reflection;
using Confluent.Kafka;
using MatchService.Database;
using MatchService.Database.Models;
using MatchService.Logging;
using MatchService.Repository;
using MatchService.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Loki;
using Serilog.Sinks.Loki.Labels;
Func<LokiSinkConfiguration> configFactory = () =>
{
    return new LokiSinkConfiguration
    {
        LokiUrl = Environment.GetEnvironmentVariable("LOKI_URL") ?? "http://loki:3100",
        LokiUsername = Environment.GetEnvironmentVariable("LOKI_USERNAME") ?? "loki_username",
        LokiPassword = Environment.GetEnvironmentVariable("LOKI_PASSWORD") ?? "loki_password",
        LogLabelProvider = new LogLabelProvider(),
        HttpClient = new LokiMatchHttpClient(),
        Period = TimeSpan.FromSeconds(10)
    };
};
var builder = WebApplication.CreateBuilder(args);

//TODO: Map services and controllers
configureLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration =  Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING") ?? "localhost:6379";
    options.InstanceName =  Environment.GetEnvironmentVariable("REDIS_INSTANCE_NAME") ?? "default";
});
builder.Services.AddDbContext<ApplicationContext>(x => {
    var Hostname=Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";
    var Port=Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
    var Name=Environment.GetEnvironmentVariable("DB_NAME") ?? "postgres";
    var Username=Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres";
    var Password=Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";
    x.UseNpgsql($"Server={Hostname}:{Port};Database={Name};Uid={Username};Pwd={Password};");
});
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder => 
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Host.UseSerilog();

builder.Services.AddScoped<IRepository<Match>, Repository<Match>>();
builder.Services.AddScoped<IRepository<Player>, Repository<Player>>();
builder.Services.AddScoped<IRepository<Status>, Repository<Status>>();
builder.Services.AddScoped<IRepository<Team>, Repository<Team>>();
builder.Services.AddScoped<IRepository<TeamRole>, Repository<TeamRole>>();

builder.Services.AddScoped<IMatchService, MatchService.Services.MatchService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRoleService, TeamRoleService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.UseHttpsRedirection();

app.Run();  

void configureLogging(){
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true).Build();
    Console.WriteLine(environment);
    Console.WriteLine(configuration);
   
    Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.LokiHttp(
                configFactory
            )
            .Enrich.WithProperty("Environment",environment)
            .ReadFrom.Configuration(configuration) 
            .CreateLogger();
}

