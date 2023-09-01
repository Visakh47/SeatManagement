using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IRepository<Building> _buildingRepository;

        public BuildingController(IRepository<Building> buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_buildingRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(BuildingDTO building)
        {
            _buildingRepository.Add(new Building
            {
                BuildingName = building.BuildingName,
                BuildingAbbreviation = building.BuildingAbbreviation
            });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_buildingRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Building building)
        {
            var originalBuilding = _buildingRepository.GetById(building.BuildingId);
            if (originalBuilding == null) { return NotFound(); }

            originalBuilding.BuildingName = building.BuildingName;
            originalBuilding.BuildingAbbreviation = building.BuildingAbbreviation;

            _buildingRepository.Update(originalBuilding);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            _buildingRepository.DeleteById(id);
            return Ok();
        }
    }

}
