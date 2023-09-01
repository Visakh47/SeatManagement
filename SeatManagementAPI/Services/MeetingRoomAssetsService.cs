using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Interfaces;

public class MeetingRoomAssetsService : IMeetingRoomAssetsService
{
    private readonly IRepository<MeetingRoomAssets> _meetingRoomAssetsRepository;

    public MeetingRoomAssetsService(IRepository<MeetingRoomAssets> meetingRoomAssetsRepository)
    {
        _meetingRoomAssetsRepository = meetingRoomAssetsRepository;
    }


    public MeetingRoomAssets[] GetAllMeetingRoomAssets()
    {
        return _meetingRoomAssetsRepository.GetAll();
    }


    public void AddMeetingRoomAsset(MeetingRoomAssetsDTO meetingRoomAsset)
    {
        _meetingRoomAssetsRepository.Add(new MeetingRoomAssets
        {
            MeetingRoomId = meetingRoomAsset.MeetingRoomId,
            AssetId = meetingRoomAsset.AssetId,
            NoOfItems = meetingRoomAsset.NoOfItems
        });
    }

 
    public MeetingRoomAssets GetMeetingRoomAssetById(int id)
    {
        return _meetingRoomAssetsRepository.GetById(id);
    }


    public void EditMeetingRoomAsset(MeetingRoomAssets meetingRoomAsset)
    {
        var originalMeetingRoomAsset = _meetingRoomAssetsRepository.GetById(meetingRoomAsset.MeetingRoomAssetId);
        if (originalMeetingRoomAsset == null)
        {
            throw new Exception("Not Found Meeting Room Asset");
        }

        originalMeetingRoomAsset.MeetingRoomId = meetingRoomAsset.MeetingRoomId;
        originalMeetingRoomAsset.AssetId = meetingRoomAsset.AssetId;
        originalMeetingRoomAsset.NoOfItems = meetingRoomAsset.NoOfItems;

        _meetingRoomAssetsRepository.Update(originalMeetingRoomAsset);
    }


    public void DeleteMeetingRoomAssetById(int id)
    {
        _meetingRoomAssetsRepository.DeleteById(id);
    }
}
