using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }

        [ForeignKey("Cabin-Facility")]
        public int FacilityId { get; set; }

        public string CabinCode { get; set; }

        [ForeignKey("Cabin-Employee")]
        public int EmployeeId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
