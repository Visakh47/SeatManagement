using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomService.GetAllMeetingRooms());
        }

        [HttpPost]
        public IActionResult Add(MeetingRoomDTO meetingRoom)
        {
            _meetingRoomService.AddMeetingRoom(meetingRoom);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_meetingRoomService.GetMeetingRoomById(id));
        }

        [HttpPut]
        public IActionResult Edit(MeetingRoom meetingRoom)
        {
            _meetingRoomService.EditMeetingRoom(meetingRoom);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _meetingRoomService.DeleteMeetingRoomById(id);
            return Ok();
        }
    }
}
