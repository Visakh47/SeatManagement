using System.ComponentModel.DataAnnotations;

namespace SeatManagementAPI.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string AssetName { get; set; }
    }
}
