namespace SeatManagementAPI.Models
{
    public class CabinUnAllocatedView
    {
        public int CabinId { get; set; }
        public string CityAbbreviation { get; set; }
        public string BuildingAbbreviation { get; set; } 
        public int FacilityFloor { get; set; } 
        public string FacilityName { get; set; } 
        public string CabinCode { get; set; } 
    }
}

