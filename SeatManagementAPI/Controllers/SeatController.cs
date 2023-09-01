using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IRepository<Seat> _seatRepository;

        public SeatController(IRepository<Seat> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_seatRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(SeatDTO seat)
        {
            _seatRepository.Add(new Seat
            {
                FacilityId = seat.FacilityId,
                SeatCode = seat.SeatCode,
                EmployeeId = seat.EmployeeId
            });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_seatRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Seat seat)
        {
            var originalSeat = _seatRepository.GetById(seat.SeatId);
            if (originalSeat == null) { return NotFound(); }

            originalSeat.FacilityId = seat.FacilityId;
            originalSeat.SeatCode = seat.SeatCode;
            originalSeat.EmployeeId = seat.EmployeeId;

            _seatRepository.Update(originalSeat);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _seatRepository.DeleteById(id);
            return Ok();
        }
    }

}
