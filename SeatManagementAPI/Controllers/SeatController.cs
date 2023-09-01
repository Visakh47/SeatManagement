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

        [HttpPost]
        public IActionResult Add(SeatDTO seat)
        {
            _seatService.AddSeat(seat);
            return Ok();
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
    }
}
