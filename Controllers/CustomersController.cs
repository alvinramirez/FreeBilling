using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeBilling.Web.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("/api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> logger;
    private readonly IBillingRepository repository;

    public CustomersController(ILogger<CustomersController> logger, IBillingRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Customer>>> Get(bool withAddresses = false)
    {
        try
        {
            IEnumerable<Customer> results;

            if (withAddresses)
            {
                results = await repository.GetCustomersWithAddresses();
            }
            else
            {
                results = await repository.GetCustomers();
            }

            return Ok(results);
        }
        catch (Exception)
        {
            logger.LogError("Failed to get customers from database.");
            return Problem("Failed to get customers from database.");
        }
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> GetOne(int id)
    {
        try
        {
            var result = await repository.GetCustomer(id);

            if (result is null) 
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            logger.LogError("Exception thrown while reading customer");
            return Problem($"Exception thrown: {ex.Message}");
        }
    }
}