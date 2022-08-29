using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEF
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=relationshipef;Trusted_Connection=True;");
        }

        //Cascade delete by Fluent API
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>()
                .HasOne(p => p.Company)
                .WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
