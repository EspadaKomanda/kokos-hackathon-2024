using Microsoft.EntityFrameworkCore;
using UserService.Database.Models;

namespace UserService.Database;

class ApplicationContext : DbContext
{
  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Profile> Profiles { get; set; } = null!;
  public DbSet<Role> Roles { get; set; } = null!;
  public DbSet<Subscription> Subscriptions { get; set; } = null!;

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>().ToTable("User");
    modelBuilder.Entity<Profile>().ToTable("Profile");
    modelBuilder.Entity<Role>().ToTable("Role");
    modelBuilder.Entity<Subscription>().ToTable("Subscription");

    // In subscriptions FanId and PlayerId must be unique together
    modelBuilder.Entity<Subscription>()
      .HasIndex(x => new { x.FanId, x.PlayerId })
      .IsUnique();
  }
} 
