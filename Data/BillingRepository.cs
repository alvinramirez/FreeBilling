using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data
{
    public class BillingRepository
    {
        private readonly BillingContext context;

        public BillingRepository(BillingContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.context.Employees
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await this.context.Customers
                .OrderBy(c => c.CompanyName)
                .ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
