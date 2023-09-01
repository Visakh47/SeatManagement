using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models.DTO
{
    public class FacilityDTO
    {
        public int CityId { get; set; }
        public int BuildingId { get; set; }
        public int FacilityFloor { get; set; }
        public string FacilityName { get; set; }

    }
}
