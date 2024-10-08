using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchService.Database
{
    
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamRole> TeamRoles { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    } 
}