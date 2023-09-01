using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpPost]
        public IActionResult Add(EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_employeeService.GetEmployeeById(id));
        }

        [HttpPut]
        public IActionResult Edit(Employee employee)
        {
            _employeeService.EditEmployee(employee);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _employeeService.DeleteEmployeeById(id);
            return Ok();
        }
    }
}
