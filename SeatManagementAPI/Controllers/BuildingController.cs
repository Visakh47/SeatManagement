using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_buildingService.GetAllBuildings());
        }

        [HttpPost]
        public IActionResult Add(BuildingDTO building)
        {
            _buildingService.AddBuilding(building);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_buildingService.GetBuildingById(id));
        }

        [HttpPut]
        public IActionResult Edit(Building building)
        {
            _buildingService.EditBuilding(building);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            _buildingService.DeleteBuildingById(id);
            return Ok();
        }
    }

}
