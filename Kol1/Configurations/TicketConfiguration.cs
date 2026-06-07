using Kol1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kol1.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(b => b.TicketId);
        builder.Property(b => b.SerialNumber).HasMaxLength(50).IsRequired();
        builder.Property(b => b.SeatNumber).IsRequired();

        // Relationship to Author is configured on AuthorConfiguration side.
        // Relationship to BookCategory is configured on BookCategoryConfiguration side.

        builder.HasData(new List<Ticket>
        {
            new Ticket { TicketId = 1, SerialNumber = "1", SeatNumber = 1 },
            new Ticket { TicketId = 2, SerialNumber = "2", SeatNumber = 2 },
            new Ticket { TicketId = 3, SerialNumber = "3", SeatNumber = 3 },
            new Ticket { TicketId = 4, SerialNumber = "4", SeatNumber = 4 },
            new Ticket { TicketId = 5, SerialNumber = "5", SeatNumber = 5 },
            new Ticket { TicketId = 6, SerialNumber = "6", SeatNumber = 6 },
            new Ticket { TicketId = 7, SerialNumber = "7", SeatNumber = 7 },
            new Ticket { TicketId = 8, SerialNumber = "8", SeatNumber = 8 },
        });
    }
}