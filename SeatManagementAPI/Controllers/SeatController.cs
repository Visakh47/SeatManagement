using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_seatService.GetAllSeats());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_seatService.GetSeatById(id));
        }

        [HttpPut]
        public IActionResult Edit(Seat seat)
        {
            _seatService.EditSeat(seat);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _seatService.DeleteSeatById(id);
            return Ok();
        }



        [HttpPatch]
        [Route("{id}")]
        public IActionResult Allocate(int id, int EmployeeId)
        {
            if (EmployeeId == 0)
                _seatService.SeatDeallocate(id);
            else
                _seatService.SeatAllocate(id, EmployeeId);
            return Ok();
        }


        [HttpPost]
        public IActionResult Add(int totalSeats, int FacilityId)
        {
            try
            {
                _seatService.AddManySeats(totalSeats, FacilityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
