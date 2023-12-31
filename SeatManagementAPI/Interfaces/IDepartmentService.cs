﻿using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Interfaces
{
    public interface IDepartmentService
    {
        Department[] GetAllDepartments();
        int AddDepartment(DepartmentDTO department);
        Department GetDepartmentById(int id);
        void EditDepartment(Department department);
        void DeleteDepartmentById(int id);

    }
}
