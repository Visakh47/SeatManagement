using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetsController : ControllerBase
    {
        private readonly IMeetingRoomAssetsService _meetingRoomAssetsService;

        public MeetingRoomAssetsController(IMeetingRoomAssetsService meetingRoomAssetsService)
        {
            _meetingRoomAssetsService = meetingRoomAssetsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomAssetsService.GetAllMeetingRoomAssets());
        }

        [HttpPost]
        public IActionResult Add(MeetingRoomAssetsDTO meetingRoomAsset)
        {
            _meetingRoomAssetsService.AddMeetingRoomAsset(meetingRoomAsset);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_meetingRoomAssetsService.GetMeetingRoomAssetById(id));
        }

        [HttpPut]
        public IActionResult Edit(MeetingRoomAssets meetingRoomAsset)
        {
            _meetingRoomAssetsService.EditMeetingRoomAsset(meetingRoomAsset);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _meetingRoomAssetsService.DeleteMeetingRoomAssetById(id);
            return Ok();
        }
    }
}
