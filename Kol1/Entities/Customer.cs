using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol1.Entities;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)]
    public string PhoneNumber { get; set; } = null!;

    // Navigation property: one Customer has many Orders
    public ICollection<PurchasedTicket> Purchases { get; set; } = [];
}