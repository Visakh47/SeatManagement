using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetsController : ControllerBase
    {
        private readonly IRepository<MeetingRoomAssets> _meetingRoomAssetsRepository;

        public MeetingRoomAssetsController(IRepository<MeetingRoomAssets> meetingRoomAssetRepository)
        {
            _meetingRoomAssetsRepository = meetingRoomAssetRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomAssetsRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(MeetingRoomAssetsDTO meetingRoomAsset)
        {
            _meetingRoomAssetsRepository.Add(new MeetingRoomAssets
            {
                MeetingRoomId = meetingRoomAsset.MeetingRoomId,
                AssetId = meetingRoomAsset.AssetId,
                NoOfItems = meetingRoomAsset.NoOfItems
            });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_meetingRoomAssetsRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(MeetingRoomAssets meetingRoomAsset)
        {
            var originalMeetingRoomAsset = _meetingRoomAssetsRepository.GetById(meetingRoomAsset.MeetingRoomAssetId);
            if (originalMeetingRoomAsset == null) { return NotFound(); }

            originalMeetingRoomAsset.MeetingRoomId = meetingRoomAsset.MeetingRoomId;
            originalMeetingRoomAsset.AssetId = meetingRoomAsset.AssetId;
            originalMeetingRoomAsset.NoOfItems = meetingRoomAsset.NoOfItems;

            _meetingRoomAssetsRepository.Update(originalMeetingRoomAsset);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _meetingRoomAssetsRepository.DeleteById(id);
            return Ok();
        }
    }

}
