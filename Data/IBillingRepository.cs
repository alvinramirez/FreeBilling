using FreeBilling.Data.Entities;

namespace FreeBilling.Web.Data;

public interface IBillingRepository
{
    Task<IEnumerable<Customer>> GetCustomers();
    Task<IEnumerable<Customer>> GetCustomersWithAddresses();
    Task<Customer?> GetCustomer(int id);
    Task <TimeBill?> GetTimeBill(int id);
    Task<IEnumerable<Employee>> GetEmployees();
    void AddEntity<T>(T entity) where T : notnull;
    Task<bool> SaveChanges();
}