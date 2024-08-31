using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreeBilling.Web.Controllers;

[Route("/api/customers/{id:int}/timebills")]
public class CustomersTimeBillsController : ControllerBase
{
    private readonly ILogger<CustomersTimeBillsController> logger;
    private readonly IBillingRepository repository;

    public CustomersTimeBillsController(ILogger<CustomersTimeBillsController> logger, 
        IBillingRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<TimeBill>>> GetCustomerTimeBills(int id)
    {
        var result = await this.repository.GetTimeBillsForCustomer(id);

        if (result is not null) return Ok(result);
        return BadRequest();
    }

    [HttpGet("{billId:int}")]
    public async Task<ActionResult<IEnumerable<TimeBill>>> GetCustomerTimeBills(int id, int billId)
    {
        var result = await this.repository.GetTimeBillForCustomer(id, billId);

        if (result is not null) return Ok(result);
        return BadRequest();
    }
}