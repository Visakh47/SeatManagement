using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

     
        public Department[] GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

      
        public void AddDepartment(DepartmentDTO department)
        {
            _departmentRepository.Add(new Department { DepartmentName = department.DepartmentName });
        }

    
        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }

  
        public void EditDepartment(Department department)
        {
            var originalDepartment = _departmentRepository.GetById(department.DepartmentId);
            if (originalDepartment == null)
            {
                throw new Exception("Not Found Dept");
            }

            originalDepartment.DepartmentName = department.DepartmentName;

            _departmentRepository.Update(originalDepartment);

        }


        public void DeleteDepartmentById(int id)
        {
            _departmentRepository.DeleteById(id);
        }
    }

}
