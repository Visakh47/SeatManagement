using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_facilityService.GetAllFacilities());
        }

        [HttpPost]
        public IActionResult Add(FacilityDTO facility)
        {
            int id = _facilityService.AddFacility(facility);
            return Ok(id);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_facilityService.GetFacilityById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Edit(Facility facility)
        {
            _facilityService.EditFacility(facility);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _facilityService.DeleteFacilityById(id);
            return Ok();
        }
    }
}
