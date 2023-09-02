using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models.DTO
{
    public class CabinDTO
    {
        public int FacilityId { get; set; }

        public string CabinCode { get; set; }
    }
}
