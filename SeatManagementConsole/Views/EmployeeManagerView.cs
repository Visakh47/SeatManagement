using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using System.ComponentModel.DataAnnotations;
using System.Xml;

internal class EmployeeManagerView
{
    private IEntityManager<Employee> employeeManager;

   

    public EmployeeManagerView(IEntityManager<Employee> employeeManager)
    {
        this.employeeManager = employeeManager;
    }

    public async void CreateView() {
        IEntityManager<Department> departmentManager = new EntityManager<Department>("Department");
        DepartmentManagerView departmentManagerView = new DepartmentManagerView(departmentManager);
        Console.Write("Enter The Employee Name?: ");
        string employeeName = Console.ReadLine();
        Console.WriteLine("Enter The Department Details?:");
        int departmentId = await departmentManagerView.CreateOrAddExistingDepartmentView();
        Employee employee = new Employee { EmployeeName = employeeName, DepartmentId = departmentId, isAllocated=false };
        employeeManager.Add(employee);
    }

    public async void CreateMultipleView() {
        Console.WriteLine("How many Employees do you need: ");
        int no = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < no; i++)
            CreateView();
    }
}