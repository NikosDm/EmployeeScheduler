using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.WebApi.DTOs;
using EmployeeScheduler.WebApi.DTOs.Employees;
using EmployeeScheduler.WebApi.Employees.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduler.WebApi.Controllers;

/// <summary>
/// Employee Api Controller
/// Contains all the actions related to Employee Entity
/// </summary>
/// <returns>Every action returns an instance of ResponseDTO class which contains data or any exception that may occur</returns>
public class EmployeeController : BaseApiController
{
    private readonly IEmployeeService _employeeService;
    protected ResponseDTO _response; 

    public EmployeeController(IEmployeeService employeeService) 
    {
        _employeeService = employeeService;
        _response = new ResponseDTO();
    }
    
    /// <summary>
    /// Action that retrieves the employees based on the filters given
    /// </summary>
    /// <param name="filterParams">Object parameter used for filtering the list of employees</param>
    [HttpGet("GetAllEmployees")]
    public async Task<ActionResult<ResponseDTO>> GetAllEmployees([FromQuery]FilterParams filterParams) 
    {
        try 
        {
            _response.Result = await _employeeService.FetchAllEmployees(filterParams);
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that retrieves a specific employee but its ID
    /// </summary>
    /// <param name="employeeID">ID of the employee</param>
    [HttpGet("GetEmployee/{employeeID}")]
    public async Task<ActionResult<ResponseDTO>> GetEmployee(string employeeID) 
    {
        try 
        {
            _response.Result = await _employeeService.FetchEmployeeByID(employeeID);
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that adds a new employee
    /// </summary>
    /// <param name="employeeDetailsDTO">Object parameter that contains all the information regarding the new employee</param>
    [HttpPost("AddNewEmployee")]
    public async Task<ActionResult<ResponseDTO>> AddNewEmployee([FromBody]EmployeeDetailsDTO employeeDetailsDTO) 
    {
        try 
        {
            var result = await _employeeService.AddNewEmployee(employeeDetailsDTO);

            if (!result) throw new Exception("New employee could not be added");

            _response.Result = result;
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that updates the information of a specific employee
    /// </summary>
    /// <param name="employeeDetailsDTO">Object parameter that contains all the updated information regarding the existing employee</param>
    [HttpPut("UpdateEmployee")]
    public async Task<ResponseDTO> UpdateEmployee([FromBody]EmployeeDetailsDTO employeeDetailsDTO) 
    {
        try 
        {
            var employee =  await _employeeService.UpdateEmployee(employeeDetailsDTO);
            _response.Result = employee;
            _response.Message = "Success";
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that deletes an employee
    /// </summary>
    /// <param name="employeeID">ID of employee</param>
    [HttpDelete("DeleteEmployee/{employeeID}")]
    public async Task<ResponseDTO> DeleteEmployee(string employeeID) 
    {
        try 
        {
            var result =  await _employeeService.DeleteEmployees(new List<string> { employeeID });
            _response.Message = "Success";
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that deletes multiple employees
    /// </summary>
    /// <param name="employeeIDs">List of selected employee IDs which should be deleted</param>
    [HttpDelete("DeleteMultipleEmployees")]
    public async Task<ResponseDTO> DeleteMultipleEmployees([FromBody]IEnumerable<string> employeeIDs) 
    {
        try 
        {
            var result =  await _employeeService.DeleteEmployees(employeeIDs);
            _response.Message = "Success";
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}
