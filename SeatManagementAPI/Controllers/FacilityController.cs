using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IRepository<Facility> _facilityRepository;

        public FacilityController(IRepository<Facility> facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_facilityRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(FacilityDTO facility)
        {
            _facilityRepository.Add(new Facility
            {
                CityId = facility.CityId,
                BuildingId = facility.BuildingId,
                FacilityFloor = facility.FacilityFloor,
                FacilityName = facility.FacilityName
            });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_facilityRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Facility facility)
        {
            var originalFacility = _facilityRepository.GetById(facility.FacilityId);
            if (originalFacility == null) { return NotFound(); }

            originalFacility.CityId = facility.CityId;
            originalFacility.BuildingId = facility.BuildingId;
            originalFacility.FacilityFloor = facility.FacilityFloor;
            originalFacility.FacilityName = facility.FacilityName;

            _facilityRepository.Update(originalFacility);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _facilityRepository.DeleteById(id);
            return Ok();
        }
    }

}
