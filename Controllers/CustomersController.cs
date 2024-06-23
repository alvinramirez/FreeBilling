using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreeBilling.Web.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly IBillingRepository repository;

        public CustomersController(IBillingRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Customer>> Get()
        {
            return await repository.GetCustomers();
        }
    }
}