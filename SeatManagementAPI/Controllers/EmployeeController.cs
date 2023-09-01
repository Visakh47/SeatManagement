using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(EmployeeDTO employee)
        {
            _employeeRepository.Add(new Employee 
            { EmployeeName = employee.EmployeeName, 
                DepartmentId = employee.DepartmentId, 
               isAllocated = false });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Employee employee)
        {
            var originalEmployee = _employeeRepository.GetById(employee.EmployeeId);
            if (originalEmployee == null)
            {
                return NotFound();
            }

            originalEmployee.EmployeeName = employee.EmployeeName;
            originalEmployee.DepartmentId = employee.DepartmentId;
            originalEmployee.isAllocated = employee.isAllocated;

            _employeeRepository.Update(originalEmployee);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _employeeRepository.DeleteById(id);
            return Ok();
        }
    }
}
