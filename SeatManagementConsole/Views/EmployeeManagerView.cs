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

    public void CreateMultipleView() {
        Console.WriteLine("How many Employees do you need: ");
        int no = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < no; i++)
            CreateView();
    }

    public async Task ListUnAllocatedEmployeesView()
    {
        IEntityManager<Department> departmentManager = new EntityManager<Department>("Department");
        await departmentManager.GetAll();
        var employees = await employeeManager.GetAll();
        Console.WriteLine($"| Employee ID | Employee Name | Department Name |");
        foreach (var employee in employees)
        {
            if (!employee.isAllocated)
            {
                Console.WriteLine($"| {employee.EmployeeId} | {employee.EmployeeName} | {employee.Department.DepartmentName} |");
            }
        }
    }

    public async Task ListAllocatedEmployeesView()
    {
        IEntityManager<Department> departmentManager = new EntityManager<Department>("Department");
        await departmentManager.GetAll();
        var employees = await employeeManager.GetAll();
        Console.WriteLine($"| Employee ID | Employee Name | Department Name |");
        foreach (var employee in employees)
        {
            if (employee.isAllocated)
            {
                Console.WriteLine($"| {employee.EmployeeId} | {employee.EmployeeName} | {employee.Department.DepartmentName} |");
            }
        }
    }

    public async Task ListEmployeesView()
    {
        IEntityManager<Department> departmentManager = new EntityManager<Department>("Department");
        departmentManager.GetAll();
        var employees = await employeeManager.GetAll();
        Console.WriteLine($"| Employee ID | Employee Name | Department Name |");
        foreach (var employee in employees)
        {
            Console.WriteLine($"| {employee.EmployeeId} | {employee.EmployeeName} | {employee.Department.DepartmentName} |");
        }
    }
}