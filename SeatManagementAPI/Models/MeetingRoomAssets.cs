using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.Models
{
    public class MeetingRoomAssets
    {
        [Key]
        public int MeetingRoomAssetId { get; set; }

        [ForeignKey("MeetingRoomAssets-MeetingRoom")]
        public int MeetingRoomId { get; set; }

        [ForeignKey("MeetingRoomAssets-Assets")]
        public int AssetId { get; set; }

        public int NoOfItems { get; set; }

        public virtual MeetingRoom MeetingRoom { get; set; }
        
        public virtual Asset Asset { get; set; }
    }
}
