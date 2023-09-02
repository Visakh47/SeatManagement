using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Views
{
    public class MeetingRoomManagerView
    {
        private IEntityManager<Seat> meetingRoomManager;

        public MeetingRoomManagerView(IEntityManager<Seat> meetingRoomManager)
        {
            this.meetingRoomManager = meetingRoomManager;
        }

        public void AddBulkMeetingRoomView(int facilityId) {
            Console.WriteLine("How many number of Meeting Rooms does the facility have?");
            var totalMeetingRooms = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Meeting Rooms Creating!");

            IEntityManager<MeetingRoom> meetingRoomManager = new EntityManager<MeetingRoom>("MeetingRoom");

            for (int i = 1; i <= totalMeetingRooms; i++)
            {
                Console.WriteLine($"How many seats for M{i:D3}");
                int meetingRoomSeatCapacity = Convert.ToInt32(Console.ReadLine());
                MeetingRoom meetingRoom = new MeetingRoom
                {
                    FacilityId = facilityId,
                    MeetingRoomCode = $"M{i:D3}",
                    TotalSeats = meetingRoomSeatCapacity
                };
                meetingRoomManager.Add(meetingRoom);
            }
        }
    }
}
