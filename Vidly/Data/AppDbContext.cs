using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cn = @"Server=.\SQLEXPRESS; Database=CapBioRent; Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(cn);

            base.OnConfiguring(optionsBuilder);
        }
    }

}
