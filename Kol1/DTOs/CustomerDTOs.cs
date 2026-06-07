namespace Kol1.DTOs;

// ----- GET /api/customers/{id} -----
public class CustomerDetailDto
{
    public int    CustomerId        { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName  { get; set; } = null!;
    public string PhoneNumber     { get; set; } = null!;
    public List<PurchasedTicketSummaryDto> Purchases { get; set; } = [];
}

public class TicketSummaryDto
{
    public string  SerialNumber { get; set; } = null!;
    public int  SeatNumber { get; set; }
}

public class ConcertSummaryDto
{
    public DateTime  Data { get; set; }
    public string  Name { get; set; } = null!;
}
public class PurchasedTicketSummaryDto
{
    public DateTime  Date   { get; set; }
    public decimal Price { get; set; }
    
    public TicketSummaryDto Ticket { get; set;} = null!;

    public ConcertSummaryDto Concert { get; set;} = null!;
}