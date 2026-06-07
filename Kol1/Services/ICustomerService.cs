using Kol1.DTOs;

namespace Kol1.Services;

public interface ICustomerService
{
    Task<CustomerDetailDto> GetCustomerByIdAsync(int id);
}