using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.DTOs.Employees;
using EmployeeScheduler.WebApi.Employees.Interfaces;

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

        if (_unitOfWork.HasChanges()) return await _unitOfWork.Complete();

        return false;
    }

    public async Task<bool> DeleteEmployees(IEnumerable<string> employeeIDs)
    {
        await _unitOfWork.employeeRepository.DeleteEmployees(employeeIDs);
        
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
        
        if (_unitOfWork.HasChanges()) await _unitOfWork.Complete();

        return _mapper.Map<EmployeeDetailsDTO>(employee);
    }

    private async Task<Employee> GetEmployee(string EmployeeID)
    {
        var employee = await _unitOfWork.employeeRepository.FetchEmployeeDetails(EmployeeID);

        if (employee == null) throw new Exception("Employee does not exist");

        return employee;
    }
}
