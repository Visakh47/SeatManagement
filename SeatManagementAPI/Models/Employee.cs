using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public bool isAllocated { get; set; }

        [ForeignKey("Employee-Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
