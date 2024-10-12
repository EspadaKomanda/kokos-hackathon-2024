using Microsoft.EntityFrameworkCore;
using UserService.Database.Models;

namespace UserService.Database;

public class ApplicationContext : DbContext
{
  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Profile> Profiles { get; set; } = null!;
  public DbSet<Role> Roles { get; set; } = null!;
  public DbSet<Subscription> Subscriptions { get; set; } = null!;

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // In subscriptions FanId and PlayerId must be unique together
    modelBuilder.Entity<Subscription>()
      .HasIndex(x => new { x.FanId, x.PlayerId })
      .IsUnique();
  }
} 
