using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
public interface IEmployeeService
{
    Employee[] GetAllEmployees();
    void AddEmployee(EmployeeDTO employee);
    Employee GetEmployeeById(int id);
    void EditEmployee(Employee employee);
    void DeleteEmployeeById(int id);
}
