using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BillingContext context;

        public IndexModel(BillingContext context)
        {
            this.context = context;
        }

        public List<Customer>? Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await this.context.Customers.ToListAsync();
        }
    }
}
