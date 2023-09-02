using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Interfaces
{
    public interface IAssetService
    {
        Asset[] GetAllAssets();
        int AddAsset(AssetDTO asset);

        Asset GetAssetById(int id);

        void EditAsset(Asset asset);

        void DeleteAssetById(int id);
    }
}
