using Kol1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kol1.Data;

public class AppDbContext : DbContext
{
    // Each DbSet<T> maps to a table in the database.
    // The property name (e.g. "Books") becomes the default table name unless overridden by [Table] attribute.
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket>   Tickets        { get; set; }
    public DbSet<TicketConcert>    TicketConcerts   { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<Customer>    Customers    { get; set; }
    protected AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This single line scans the assembly for all classes implementing
        // IEntityTypeConfiguration<T> and applies them automatically.
        // You never need to call modelBuilder.Entity<X>() manually here.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}