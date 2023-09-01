using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }

        [ForeignKey("Facility-City")]
        public int CityId { get; set; }

        [ForeignKey("Facility-Building")]
        public int BuildingId { get; set; }

        public int FacilityFloor { get; set; }
        public string FacilityName { get; set; }

        public virtual Building Building { get; set; }
        public virtual City City { get; set; }
    }
}
