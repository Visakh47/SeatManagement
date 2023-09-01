using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public interface IMeetingRoomAssetsService
{
    MeetingRoomAssets[] GetAllMeetingRoomAssets();
    void AddMeetingRoomAsset(MeetingRoomAssetsDTO meetingRoomAsset);
    MeetingRoomAssets GetMeetingRoomAssetById(int id);
    void EditMeetingRoomAsset(MeetingRoomAssets meetingRoomAsset);
    void DeleteMeetingRoomAssetById(int id);
}
