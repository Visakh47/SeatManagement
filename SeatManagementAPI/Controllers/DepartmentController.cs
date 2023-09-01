using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_departmentRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(DepartmentDTO department)
        {
            _departmentRepository.Add(new Department { DepartmentName = department.DepartmentName });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_departmentRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Department department)
        {
            var originalDepartment = _departmentRepository.GetById(department.DepartmentId);
            if (originalDepartment == null)
            {
                return NotFound();
            }

            originalDepartment.DepartmentName = department.DepartmentName;

            _departmentRepository.Update(originalDepartment);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _departmentRepository.DeleteById(id);
            return Ok();
        }
    }

}
