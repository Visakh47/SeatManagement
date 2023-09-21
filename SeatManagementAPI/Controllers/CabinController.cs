using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly ICabinService _cabinService;

        public CabinController(ICabinService cabinService)
        {
            _cabinService = cabinService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cabinService.GetAllCabins());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cabinService.GetCabinById(id));
        }

        [HttpPut]
        public IActionResult Edit(Cabin cabin)
        {
            _cabinService.EditCabin(cabin);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cabinService.DeleteById(id);
            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Allocate(int id, int EmployeeId)
        {
            if (EmployeeId == 0)
                _cabinService.CabinDeallocate(id); 
            else
                _cabinService.CabinAllocate(id, EmployeeId);
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(int totalCabins, int FacilityId)
        {
            try
            {
                _cabinService.AddManyCabins(totalCabins, FacilityId);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }

}
