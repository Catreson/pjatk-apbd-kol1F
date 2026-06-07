using Kol1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kol1.Configurations;

public class PurchasedTicketConfiguration : IEntityTypeConfiguration<PurchasedTicket>
{
    public void Configure(EntityTypeBuilder<PurchasedTicket> builder)
    {
        builder.HasKey(bc => new { bc.TicketConcertId, bc.CustomerId });
        builder.HasOne(bc => bc.Customer)
               .WithMany(b => b.Purchases)
               .HasForeignKey(bc => bc.CustomerId);

        builder.HasOne(bc => bc.TicketConcert)
               .WithMany(c => c.Customers)
               .HasForeignKey(bc => bc.TicketConcertId);
        builder.Property(b => b.PurchaseDate).IsRequired();


        // Relationship to Author is configured on AuthorConfiguration side.
        // Relationship to BookCategory is configured on BookCategoryConfiguration side.

        builder.HasData(new List<PurchasedTicket>
        {
            new PurchasedTicket { TicketConcertId = 1, CustomerId = 1, PurchaseDate = new DateTime(2026,6,1) },
            new PurchasedTicket { TicketConcertId = 2, CustomerId = 1, PurchaseDate = new DateTime(2026,6,1) },
            new PurchasedTicket { TicketConcertId = 3, CustomerId = 1, PurchaseDate = new DateTime(2026,6,1) },
            new PurchasedTicket { TicketConcertId = 4, CustomerId = 1, PurchaseDate = new DateTime(2026,6,1) },
            new PurchasedTicket { TicketConcertId = 5, CustomerId = 1, PurchaseDate = new DateTime(2026,6,1) },
        });
    }
}