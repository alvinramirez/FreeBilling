using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreeBilling.Web.Controllers
{
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IBillingRepository repository;

        public CustomersController(IBillingRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await repository.GetCustomers();
        }
        [HttpGet("{id:int}")]
        public async Task<Customer?> GetOne(int id)
        {
            return await repository.GetCustomer(id);
        }
    }
}