using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol1.Entities;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [MaxLength(50)]
    public string SerialNumber { get; set; } = null!;

    public int SeatNumber { get; set; }

    // Navigation property: many Books belong to many Categories (via BookCategory join table)
    public ICollection<TicketConcert> Concerts { get; set; } = [];
}