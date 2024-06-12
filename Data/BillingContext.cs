using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data
{
    public class BillingContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeBill> TimeBills => Set<TimeBill>();
    }
}
