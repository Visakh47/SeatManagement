using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public class MeetingRoomService : IMeetingRoomService
{
    private readonly IRepository<MeetingRoom> _meetingRoomRepository;

    public MeetingRoomService(IRepository<MeetingRoom> meetingRoomRepository)
    {
        _meetingRoomRepository = meetingRoomRepository;
    }

   
    public MeetingRoom[] GetAllMeetingRooms()
    {
        return _meetingRoomRepository.GetAll();
    }

  
    public int AddMeetingRoom(MeetingRoomDTO meetingRoom)
    {
        MeetingRoom mr = new MeetingRoom
        {
            FacilityId = meetingRoom.FacilityId,
            MeetingRoomCode = meetingRoom.MeetingRoomCode,
            TotalSeats = meetingRoom.TotalSeats
        };
        _meetingRoomRepository.Add(mr);

        return mr.MeetingRoomId;
    }


    public MeetingRoom GetMeetingRoomById(int id)
    {
        return _meetingRoomRepository.GetById(id);
    }

 
    public void EditMeetingRoom(MeetingRoom meetingRoom)
    {
        var originalMeetingRoom = _meetingRoomRepository.GetById(meetingRoom.MeetingRoomId);
        if (originalMeetingRoom == null)
        {
            throw new Exception("Not Found Meeting Room");
        }

        originalMeetingRoom.FacilityId = meetingRoom.FacilityId;
        originalMeetingRoom.MeetingRoomCode = meetingRoom.MeetingRoomCode;
        originalMeetingRoom.TotalSeats = meetingRoom.TotalSeats;

        _meetingRoomRepository.Update(originalMeetingRoom);
    }

 
    public void DeleteMeetingRoomById(int id)
    {
        _meetingRoomRepository.DeleteById(id);
    }
}
