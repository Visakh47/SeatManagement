using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class MeetingRoom
    {
        [Key]
        public int MeetingRoomId { get; set; }

        [ForeignKey("MeetingRoom-Facility")]
        public int FacilityId { get; set; }
        public string MeetingRoomCode { get; set; }
        public int TotalSeats { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
