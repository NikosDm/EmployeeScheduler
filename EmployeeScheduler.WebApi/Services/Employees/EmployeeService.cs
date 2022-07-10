using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.DTOs.Employees;
using EmployeeScheduler.WebApi.Interfaces.Employees;

namespace EmployeeScheduler.WebApi.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IMapper _mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<bool> AddNewEmployee(EmployeeDetailsDTO employeeDetailsDTO)
    {
        var employee = _mapper.Map<Employee>(employeeDetailsDTO);

        await _unitOfWork.employeeRepository.AddNewEmployee(employee);

        /*Storing the employee entity first so that I can get the generated KEY*/
        if (_unitOfWork.HasChanges()) await _unitOfWork.Complete();

        await InsertAuditTrailRecord("CREATE", employee);

        if (_unitOfWork.HasChanges()) return await _unitOfWork.Complete();

        return false;
    }

    public async Task<bool> DeleteEmployees(ICollection<string> employeeIDs)
    {
        var employees = await _unitOfWork.employeeRepository.FetchEmployeesByIds(employeeIDs);

        if (employees.Count != employeeIDs.Count) throw new Exception("Some of the employee IDs are invalid. Please try again using valid ones");

        await _unitOfWork.employeeRepository.DeleteEmployees(employees);

        foreach (var employee in employees)
            await InsertAuditTrailRecord("DELETE", employee); 
        
        if (_unitOfWork.HasChanges()) return await _unitOfWork.Complete();

        return false;
    }

    public async Task<IEnumerable<EmployeeListDTO>> FetchAllEmployees(FilterParams filterParams)
    {
        var employees = await _unitOfWork.employeeRepository.FetchEmployees(filterParams);

        return _mapper.Map<IEnumerable<EmployeeListDTO>>(employees);
    }

    public async Task<EmployeeDetailsDTO> FetchEmployeeByID(string EmployeeID)
    {
        var employee = await GetEmployee(EmployeeID);

        return _mapper.Map<EmployeeDetailsDTO>(employee);
    }

    public async Task<EmployeeDetailsDTO> UpdateEmployee(EmployeeDetailsDTO employeeDetailsDTO)
    {
        var employee = await GetEmployee(employeeDetailsDTO.EmployeeID);

        employee.updateValues(employeeDetailsDTO.FirstName, 
            employeeDetailsDTO.LastName, employeeDetailsDTO.Email, 
            employeeDetailsDTO.JobTitle, employeeDetailsDTO.HiringDate, 
            employeeDetailsDTO.EmployeeType, employeeDetailsDTO.DateOfBirth);

        employee.updateSkills(employeeDetailsDTO.Skills);

        employee = await _unitOfWork.employeeRepository.UpdateEmployee(employee);

        await InsertAuditTrailRecord("UPDATE", employee);
        
        if (_unitOfWork.HasChanges()) await _unitOfWork.Complete();

        return _mapper.Map<EmployeeDetailsDTO>(employee);
    }

    private async Task<Employee> GetEmployee(string EmployeeID)
    {
        var employee = await _unitOfWork.employeeRepository.FetchEmployeeDetails(EmployeeID);

        if (employee == null) throw new Exception("Employee does not exist");

        return employee;
    }

    private async Task InsertAuditTrailRecord(string action, Employee employee) 
    {
        var auditTrail = await AuditTrailHelper<Employee>.AddAuditTrailRecordAsync(employee, action);

        await _unitOfWork.auditTrailRepository.AddNewAuditTrailRecord(auditTrail);
    }
}
