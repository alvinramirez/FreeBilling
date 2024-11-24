using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data;

public class BillingRepository : IBillingRepository
{
    private readonly BillingContext context;
    private readonly ILogger<BillingRepository> logger;

    public BillingRepository(BillingContext context, ILogger<BillingRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        try
        {
            return await this.context.Employees
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError($"Could not get employees: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            return await this.context.Customers
            .OrderBy(c => c.CompanyName)
            .ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError($"Could not get Customers: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomersWithAddresses()
    {
        try
        {
            return await this.context.Customers
            .Include(c => c.Address)
            .OrderBy(c => c.CompanyName)
            .ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError($"Could not get Customers: {ex.Message}");
            throw;
        }
    }

    public async Task<Customer?> GetCustomer(int id)
    {
        try
        {
            return await this.context.Customers
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            logger.LogError($"Could not get Customers: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> SaveChanges()
    {
        try
        {
            return await context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            logger.LogError($"Could not save to the Database: {ex.Message}");
            throw;
        }
    }

    public async Task<TimeBill?> GetTimeBill(int id)
    {
        var bill = await context.TimeBills
            .Include(b => b.Employee)
            .Include(b => b.Customer)
            .ThenInclude(c => c!.Address)
            .Where(b => b .Id == id)
            .FirstOrDefaultAsync();

        return bill;
    }

    public void AddEntity<T>(T entity) where T : notnull
    {
        context.Add(entity);
    }

    public async Task<IEnumerable<TimeBill>> GetTimeBillsForCustomer(int id)
    {
        return await context.TimeBills
            .Where(b => b.CustomerId != null && b.CustomerId == id)
            .Include(b => b.Customer)
            .Include(b => b.Employee)
            .ToListAsync();
    }

    public async Task<TimeBill?> GetTimeBillForCustomer(int id, int billId)
    {
        return await context.TimeBills
            .Where(b => b.CustomerId != null && b.CustomerId == id && b.Id == billId)
            .Include(b => b.Customer)
            .Include(b => b.Employee)
            .FirstOrDefaultAsync    ();
    }

    public async Task<Employee?> GetEmployee(string name)
    {
        return await context.Employees
            .Where(e => e.Email == name)
            .FirstOrDefaultAsync();
    }

    public async Task<object?> GetAuth()
    {
        return await Task.FromResult<object?>(null);
    }
}
