using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly.Models;

namespace Vidly.Data
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(p => p.ReleaseDate)
                .HasColumnType("date");

            builder
                .Property(p => p.DateAdded)
                .HasColumnType("date");
        }
    }
}
