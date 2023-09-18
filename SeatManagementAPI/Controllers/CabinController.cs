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

        [HttpPost]
        public IActionResult Add(CabinDTO cabin)
        {
            _cabinService.AddCabin(cabin);
            return Ok();
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
        [Route("allocate")]
        public IActionResult Allocate(int cabinId, int EmployeeId)
        {
            _cabinService.CabinAllocate(cabinId, EmployeeId);
            return Ok();
        }

        [HttpPatch]
        [Route("deallocate")]
        public IActionResult Deallocate(int cabinId)
        {
            _cabinService.CabinDeallocate(cabinId);
            return Ok();
        }

        [HttpPost]
        [Route("addbatch")]
        public IActionResult AddBatch(int totalCabins, int FacilityId)
        {
            _cabinService.AddManyCabins(totalCabins, FacilityId);
            return Ok();
        }
    }

}
