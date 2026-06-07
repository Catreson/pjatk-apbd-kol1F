using Kol1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kol1.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.CustomerId);
        builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(200);

        // One Customer has many Orders
        builder.HasMany(c => c.Purchases)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Customer>
        {
            new Customer { CustomerId = 1, FirstName = "Anna",   LastName = "Kowalska",  PhoneNumber = "696969696" },
            new Customer { CustomerId = 2, FirstName = "Janusz",  LastName = "Kowalski", PhoneNumber = "969696969" },
            new Customer { CustomerId = 3, FirstName = "Jan",  LastName = "Paweł", PhoneNumber = "213797312" },
        });
    }
}