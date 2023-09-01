using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;
    


    public EmployeeService(IRepository<Employee> employeeRepository, IDepartmentService _departmentService)
    {
        _employeeRepository = employeeRepository;
        _departmentService.GetAllDepartments();
    }


    public Employee[] GetAllEmployees()
    {
        return _employeeRepository.GetAll();
    }

 
    public void AddEmployee(EmployeeDTO employee)
    {
        _employeeRepository.Add(new Employee 
        { EmployeeName = employee.EmployeeName,
            DepartmentId = employee.DepartmentId,
            isAllocated = false,
        }
        );
    }

  
    public Employee GetEmployeeById(int id)
    {
        return _employeeRepository.GetById(id);
    }


    public void EditEmployee(Employee employee)
    {
        var originalEmployee = _employeeRepository.GetById(employee.EmployeeId);
        if (originalEmployee == null)
        {
            throw new Exception("Not Found Employee");
        }

        originalEmployee.EmployeeName = employee.EmployeeName;

        _employeeRepository.Update(originalEmployee);
    }


    public void DeleteEmployeeById(int id)
    {
        _employeeRepository.DeleteById(id);
    }
}
