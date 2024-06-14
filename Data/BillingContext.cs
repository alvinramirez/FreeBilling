using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data
{
    public class BillingContext : DbContext
    {
        private readonly IConfiguration config;

        public BillingContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeBill> TimeBills => Set<TimeBill>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = this.config["ConnectionStrings:BillingDb"];
            optionsBuilder.UseSqlServer();
        }
    }
}
