using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    public class AssetService : IAssetService
        {
            private readonly IRepository<Asset> _assetRepository;

            public AssetService(IRepository<Asset> assetRepository)
            {
                _assetRepository = assetRepository;
            }
            public Asset[] GetAllAssets()
            {
                return _assetRepository.GetAll();
            }

            public int AddAsset(AssetDTO asset)
            {
                Asset a = new Asset { AssetName = asset.AssetName };
                _assetRepository.Add(a);
                return a.AssetId;
            }

            public Asset GetAssetById(int id)
            {
                return _assetRepository.GetById(id);
            }

            public void EditAsset(Asset asset)
            {
                var originalAsset = _assetRepository.GetById(asset.AssetId);
                if (originalAsset == null) { throw new Exception("Asset doesn't exist"); }

                originalAsset.AssetName = asset.AssetName;

                _assetRepository.Update(originalAsset);
            }

            public void DeleteAssetById(int id)
            {
                _assetRepository.DeleteById(id);
            }
        }
    }

