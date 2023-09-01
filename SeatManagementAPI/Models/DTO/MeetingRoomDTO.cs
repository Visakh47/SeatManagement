using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models.DTO
{
    public class MeetingRoomDTO
    {
        public int FacilityId { get; set; }
        public string MeetingRoomCode { get; set; }
        public int TotalSeats { get; set; }
    }
}
