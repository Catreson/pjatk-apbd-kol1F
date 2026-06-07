using Kol1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kol1.Configurations;

public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.HasKey(b => b.ConcertId);
        builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Date).IsRequired();
        builder.Property(b => b.AvailableTickets).IsRequired();

        // Relationship to Author is configured on AuthorConfiguration side.
        // Relationship to BookCategory is configured on BookCategoryConfiguration side.

        builder.HasData(new List<Concert>
        {
            new Concert { ConcertId = 1, Name = "Koncert1", Date = new DateTime(2026,9,1), AvailableTickets = 100},
            new Concert { ConcertId = 2, Name = "Koncert2", Date = new DateTime(2026,9,2), AvailableTickets = 200},
            new Concert { ConcertId = 3, Name = "Koncert3", Date = new DateTime(2026,9,3), AvailableTickets = 300},
        });
    }
}