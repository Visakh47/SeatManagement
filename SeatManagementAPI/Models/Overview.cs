namespace SeatManagementAPI.Models
{
    public class Overview { 
        public int SeatId { get; set; }
        public string CityAbbreviation { get; set; }
        public string BuildingAbbreviation { get; set; } 
        public int FacilityFloor { get; set; } 
        public string FacilityName { get; set; } 
        public string SeatCode { get; set; } 
        public string EmployeeName { get; set; }
    }
}
