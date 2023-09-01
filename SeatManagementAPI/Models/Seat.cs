using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [ForeignKey("Seat-Facility")]
        public int FacilityId { get; set; }

        public string SeatCode { get; set; }

        [ForeignKey("Seat-Employee")]
        public int? EmployeeId { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
