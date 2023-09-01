using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_departmentService.GetAllDepartments());
        }

        [HttpPost]
        public IActionResult Add(DepartmentDTO department)
        {
            _departmentService.AddDepartment(department);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_departmentService.GetDepartmentById(id));
        }

        [HttpPut]
        public IActionResult Edit(Department department)
        {
            _departmentService.EditDepartment(department);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _departmentService.DeleteDepartmentById(id);
            return Ok();
        }
    }

}
