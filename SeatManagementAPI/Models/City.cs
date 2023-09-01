using System.ComponentModel.DataAnnotations;

namespace SeatManagementAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityAbbreviation { get; set; }
    }
}
