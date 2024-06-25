using FreeBilling.Data.Entities;

namespace FreeBilling.Web.Data;

public interface IBillingRepository
{
    Task<IEnumerable<Customer>> GetCustomers();
    Task<IEnumerable<Customer>> GetCustomersWithAddresses();
    Task<Customer?> GetCustomer(int id);

    Task<IEnumerable<Employee>> GetEmployees();
    Task<bool> SaveChanges();
}