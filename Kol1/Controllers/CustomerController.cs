using Kol1.Exceptions;
using Kol1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol1.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}/purchases/")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}