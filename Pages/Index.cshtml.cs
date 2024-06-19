using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBillingRepository repository;

        public IndexModel(IBillingRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Customer>? Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await repository.GetCustomers();
        }
    }
}
