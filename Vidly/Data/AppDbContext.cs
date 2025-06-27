using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

}
