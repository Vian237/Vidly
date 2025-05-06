using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly.Models;

namespace Vidly.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(p => p.Birthdate)
                .HasColumnType("date");
        }
    }
}
