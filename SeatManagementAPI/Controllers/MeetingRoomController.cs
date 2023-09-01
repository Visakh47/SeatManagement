using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;

        public MeetingRoomController(IRepository<MeetingRoom> meetingRoomRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(MeetingRoomDTO meetingRoom)
        {
            _meetingRoomRepository.Add(new MeetingRoom
            {
                FacilityId = meetingRoom.FacilityId,
                MeetingRoomCode = meetingRoom.MeetingRoomCode,
                TotalSeats = meetingRoom.TotalSeats
            });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_meetingRoomRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(MeetingRoom meetingRoom)
        {
            var originalMeetingRoom = _meetingRoomRepository.GetById(meetingRoom.MeetingRoomId);
            if (originalMeetingRoom == null) { return NotFound(); }

            originalMeetingRoom.FacilityId = meetingRoom.FacilityId;
            originalMeetingRoom.MeetingRoomCode = meetingRoom.MeetingRoomCode;
            originalMeetingRoom.TotalSeats = meetingRoom.TotalSeats;

            _meetingRoomRepository.Update(originalMeetingRoom);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _meetingRoomRepository.DeleteById(id);
            return Ok();
        }
    }

}
