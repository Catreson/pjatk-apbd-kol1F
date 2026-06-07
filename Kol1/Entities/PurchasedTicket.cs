using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol1.Entities;

// Many-to-many join table between Book and Category
// Composite primary key: (BookId, CategoryId)
[Table("Purchased_Ticket")]
[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]
public class PurchasedTicket
{
    [ForeignKey(nameof(TicketConcert))]
    public int TicketConcertId { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    public DateTime PurchaseDate {get;set;}

    // Navigation properties
    public TicketConcert TicketConcert { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}