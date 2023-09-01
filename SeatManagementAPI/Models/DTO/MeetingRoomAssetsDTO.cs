using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeatManagementAPI.Models.DTO
{
    public class MeetingRoomAssetsDTO
    {
        public int MeetingRoomId { get; set; }
        public int AssetId { get; set; }
        public int NoOfItems { get; set; }
    }
}
