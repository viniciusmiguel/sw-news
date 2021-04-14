
using System;
using Microsoft.EntityFrameworkCore;
using Skyworkz.News.Domain;

namespace Skyworkz.News.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("cosmos-connection-string");
            Console.WriteLine("Connection String Loaded: " + connectionString);
            optionsBuilder.UseCosmos(connectionString, "skyworkz-news-cosmos-db-sql");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsEntity>()
                .ToContainer("News")
                .Property(e => e.When)
                .HasConversion<string>();


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NewsEntity> News { get; protected set; }
    }
}
