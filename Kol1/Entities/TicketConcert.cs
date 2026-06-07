using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Kol1.Entities;

// Many-to-many join table between Book and Category
// Composite primary key: (BookId, CategoryId)
[Table("Ticket_Concert")]
[PrimaryKey(nameof(TicketId), nameof(ConcertId))]
public class TicketConcert
{
    [Key]
    public int TicketConcertId { get; set; }

    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }

    [ForeignKey(nameof(Concert))]
    public int ConcertId { get; set; }

    // Navigation properties
    public Ticket Ticket { get; set; } = null!;
    public Concert Concert { get; set; } = null!;

    [Column(TypeName = "numeric(10,2)")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    public ICollection<PurchasedTicket> Customers { get; set; } = [];

}