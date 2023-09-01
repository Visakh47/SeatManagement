using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AssetController : ControllerBase
        {
            private readonly IAssetService _assetService;

            public AssetController(IAssetService assetService)
            {
                _assetService = assetService;
            }

            [HttpGet]
            public IActionResult Index()
            {
                return Ok(_assetService.GetAllAssets());
            }

            [HttpPost]
            public IActionResult Add(AssetDTO asset)
            {
                _assetService.AddAsset(asset);
                return Ok();
            }

            [HttpGet]
            [Route("{id}")]
            public IActionResult GetById(int id)
            {
                return Ok(_assetService.GetAssetById(id));
            }

            [HttpPut]
            public IActionResult Edit(Asset asset)
            {
                _assetService.EditAsset(asset);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeleteById(int id)
            {
                _assetService.DeleteAssetById(id);
                return Ok();
            }
        }
    }

