
using System;
using Microsoft.EntityFrameworkCore;
using Skyworkz.News.Domain;

namespace Skyworkz.News.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("cosmos-connection-string");
            optionsBuilder.UseCosmos(connectionString, "skyworkz-news-cosmos-db-sql");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsEntity>()
                .ToContainer("News");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NewsEntity> News { get; protected set; }
    }
}
