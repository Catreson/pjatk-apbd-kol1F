using Kol1.Data;
using Kol1.DTOs;
using Kol1.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kol1.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _db;

    public CustomerService(AppDbContext db)
    {
        _db = db;
    }

    // GET customer with all their orders and per-order totals
    // Demonstrates: nested Select projections and computed aggregates in LINQ
    public async Task<CustomerDetailDto> GetCustomerByIdAsync(int id)
    {
        var customer = await _db.Customers
            .Select(c => new CustomerDetailDto
            {
                CustomerId  = c.CustomerId,
                FirstName = c.FirstName,
                LastName  = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Purchases    = c.Purchases
                    .Select(o => new PurchasedTicketSummaryDto
                    {
                        Date = o.PurchaseDate,
                        Price = o.TicketConcert.Price,
                        Ticket = new TicketSummaryDto
                        {
                            SerialNumber = o.TicketConcert.Ticket.SerialNumber,
                            SeatNumber = o.TicketConcert.Ticket.SeatNumber
                        },
                        Concert = new ConcertSummaryDto
                        {
                            Name = o.TicketConcert.Concert.Name,
                            Data = o.TicketConcert.Concert.Date,
                        }
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(c => c.CustomerId == id);

        if (customer is null)
            throw new NotFoundException($"Customer with id {id} was not found.");

        return customer;
    }
}