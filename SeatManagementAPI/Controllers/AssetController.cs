using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AssetController : ControllerBase
        {
            private readonly IRepository<Asset> _assetRepository;

            public AssetController(IRepository<Asset> assetRepository)
            {
                _assetRepository = assetRepository;
            }

            [HttpGet]
            public IActionResult Index()
            {
                return Ok(_assetRepository.GetAll());
            }

            [HttpPost]
            public IActionResult Add(AssetDTO asset)
            {
                _assetRepository.Add(new Asset { AssetName = asset.AssetName });
                return Ok();
            }

            [HttpGet]
            [Route("{id}")]
            public IActionResult GetById(int id)
            {
                return Ok(_assetRepository.GetById(id));
            }

            [HttpPut]
            public IActionResult Edit(Asset asset)
            {
                var originalAsset = _assetRepository.GetById(asset.AssetId);
                if (originalAsset == null) { return NotFound(); }

                originalAsset.AssetName = asset.AssetName;

                _assetRepository.Update(originalAsset);

                return Ok();
            }

            [HttpDelete]
            public IActionResult DeleteById(int id)
            {
                _assetRepository.DeleteById(id);
                return Ok();
            }
        }
    }

