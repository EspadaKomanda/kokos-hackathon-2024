using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogService.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DialogService.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Dialog> Dialogs { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dialog>().HasMany(x => x.Messages).WithOne(x => x.Dialog).HasForeignKey(x => x.DialogId);
            
        }
    }
}