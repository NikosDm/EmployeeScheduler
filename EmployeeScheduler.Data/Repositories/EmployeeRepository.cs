using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduler.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dbContext;

    public EmployeeRepository(DataContext context)
    {
        _dbContext = context;
    }

    public async Task AddNewEmployee(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
    }

    public async Task DeleteEmployees(IEnumerable<string> employeeIDs)
    {
        var employees = await _dbContext.Employees.Where(x => employeeIDs.Any(y => x.EmployeeID == y)).ToListAsync();

        _dbContext.Employees.RemoveRange(employees);
    }

    public async Task<Employee> FetchEmployeeDetails(string EmployeeID)
    {
        return await _dbContext.Employees.Include(p => p.Skills).FirstOrDefaultAsync(x => x.EmployeeID == EmployeeID);
    }

    public async Task<IEnumerable<Employee>> FetchEmployees(FilterParams filterParams)
    {
        var query = _dbContext.Employees.Include(p => p.Skills).AsQueryable();

        if (!string.IsNullOrWhiteSpace(filterParams.SearchValue))
            query = query.Where(x => x.FirstName.ToLower().Contains(filterParams.SearchValue.ToLower())
                || x.LastName.ToLower().Contains(filterParams.SearchValue.ToLower())
                || x.JobTitle.ToLower().Contains(filterParams.SearchValue.ToLower())
                || x.Skills.Any(y => y.Skill.Title.ToLower().Contains(filterParams.SearchValue.ToLower())));

        /*If no value has been provided on the filter parameters
        then the list will fetch employees on a descending order based on the date they were inserted.
        In the way, the newest employees will be always shown first.
        */
        if (filterParams.SortDirection == "DESC")
            query = filterParams.SortColumn switch 
            {
                "FirstName" => query.OrderByDescending(x => x.FirstName),
                "LastName" => query.OrderByDescending(x => x.LastName),
                "JobTitle" => query.OrderByDescending(x => x.JobTitle),
                _ => query.OrderByDescending(x => x.CreateDate),
            };
        else 
            query = filterParams.SortColumn switch 
            {
                "FirstName" => query.OrderBy(x => x.FirstName),
                "LastName" => query.OrderBy(x => x.LastName),
                "JobTitle" => query.OrderBy(x => x.JobTitle),
                _ => query.OrderByDescending(x => x.CreateDate),
            };

        return await query.ToListAsync();
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        _dbContext.Employees.Update(employee);

        return await Task.FromResult(employee);
    }
}
