using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public interface IMeetingRoomService
{
    MeetingRoom[] GetAllMeetingRooms();
    int AddMeetingRoom(MeetingRoomDTO meetingRoom);
    MeetingRoom GetMeetingRoomById(int id);
    void EditMeetingRoom(MeetingRoom meetingRoom);
    void DeleteMeetingRoomById(int id);
}
