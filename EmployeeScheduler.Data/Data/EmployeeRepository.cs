using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Interfaces;

namespace EmployeeScheduler.Data.Data;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
    }

    public Task<Employee> AddNewEmployee()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEmployee()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> FetchEmployeeDetails()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> FetchEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> UpdateEmployee()
    {
        throw new NotImplementedException();
    }
}
