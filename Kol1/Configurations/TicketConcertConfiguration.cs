using Kol1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kol1.Configurations;

public class TicketConcertConfiguration : IEntityTypeConfiguration<TicketConcert>
{
    public void Configure(EntityTypeBuilder<TicketConcert> builder)
    {
        // Composite primary key
        builder.HasKey(b => b.TicketConcertId);

        // Relationships: BookCategory is the join table between Book and Category
        builder.HasOne(bc => bc.Ticket)
               .WithMany(b => b.Concerts)
               .HasForeignKey(bc => bc.TicketId);

        builder.HasOne(bc => bc.Concert)
               .WithMany(c => c.Tickets)
               .HasForeignKey(bc => bc.ConcertId);

        builder.Property(b => b.Price).HasColumnType("numeric(10,2)").IsRequired();

        // Seed data - which books belong to which categories
        builder.HasData(new List<TicketConcert>
        {
            new TicketConcert { TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 1.1M },
            new TicketConcert { TicketConcertId = 2, TicketId = 2, ConcertId = 1, Price = 1.1M },
            new TicketConcert { TicketConcertId = 3, TicketId = 3, ConcertId = 1, Price = 1.1M },
            new TicketConcert { TicketConcertId = 4, TicketId = 4, ConcertId = 2, Price = 1.1M },
            new TicketConcert { TicketConcertId = 5, TicketId = 5, ConcertId = 1, Price = 1.1M },
            new TicketConcert { TicketConcertId = 6, TicketId = 6, ConcertId = 3, Price = 1.1M },
        });
    }
}