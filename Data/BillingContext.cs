using FreeBilling.Data.Entities;
using FreeBilling.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data
{
    public class BillingContext : IdentityDbContext<TimeBillUser>
    {
        private readonly IConfiguration _config;

        public BillingContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeBill> TimeBills => Set<TimeBill>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = _config["ConnectionStrings:BillingDb"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address()
                    {
                        Id = 1,
                        AddressLine1 = "123 Main Street",
                        City = "Atlanta",
                        StateProvince = "GA",
                        PostalCode = "12345"
                    },
                    new Address()
                    {
                        Id = 2,
                        AddressLine1 = "123 First Avenue",
                        City = "Atlanta",
                        StateProvince = "GA",
                        PostalCode = "12345"
                    });

            modelBuilder.Entity<Customer>()
                .HasData(new
                {
                    Id = 1,
                    CompanyName = "Smith Towing",
                    AddressId = 1,
                    Contact = "Jim",
                    PhoneNumer = "555-1212"
                },
                new
                {
                    Id = 2,
                    CompanyName = "Paintorama",
                    AddressId = 2,
                    Contact = "Phyllis",
                    PhoneNumber = "555-2121"
                });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee()
                {
                    Id = 1,
                    Name = "Mary Jones",
                    BillingRate = 220f,
                    ImageUrl = "/img/mary.jpg",
                    Email = "mary@freebilling.com"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Betty Patel",
                    BillingRate = 85f,
                    ImageUrl = "/img/betty.jpg",
                    Email = "betty@freebilling.com"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Nancy Smith",
                    BillingRate = 115f,
                    ImageUrl = "/img/nancy.jpg",
                    Email = "nancy@freebilling.com"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "John Phillips",
                    BillingRate = 145f,
                    ImageUrl = "/img/john.jpg",
                    Email = "john@freebilling.com"
                });
        }
    }
}
