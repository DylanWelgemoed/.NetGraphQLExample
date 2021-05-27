using GraphQL.Test.GQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Test.GQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DataLeak> DataLeaks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.DataLeaks)
                .WithOne(u => u.User!)
                .HasForeignKey(u => u.UserId);

            modelBuilder
                .Entity<DataLeak>()
                .HasOne(dl => dl.User)
                .WithMany(dl => dl.DataLeaks)
                .HasForeignKey(dl => dl.UserId);
        }
    }
}