using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models.DTO
{
    public class SeatDTO
    {
        public int FacilityId { get; set; }
        public string SeatCode { get; set; }
        public int EmployeeId { get; set; }
    }
}
