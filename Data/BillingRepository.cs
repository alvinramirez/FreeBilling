﻿using FreeBilling.Data.Entities;
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
}