using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public interface IMeetingRoomService
{
    MeetingRoom[] GetAllMeetingRooms();
    void AddMeetingRoom(MeetingRoomDTO meetingRoom);
    MeetingRoom GetMeetingRoomById(int id);
    void EditMeetingRoom(MeetingRoom meetingRoom);
    void DeleteMeetingRoomById(int id);
}
