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
        private IEntityManager<MeetingRoom> meetingRoomManager;

        public MeetingRoomManagerView(IEntityManager<MeetingRoom> meetingRoomManager)
        {
            this.meetingRoomManager = meetingRoomManager;
        }

        public async Task AddBulkMeetingRoomView(int facilityId) {

            IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager = new EntityManager<MeetingRoomAssets>("MeetingRoomAssets");
            IEntityManager<Asset> assetManager = new EntityManager<Asset>("Asset");
            AssetManagerView assetManagerView = new AssetManagerView(assetManager);
            int assetId;
            int meetingRoomId;

            Console.Write("How many number of Meeting Rooms does the facility have:");
            var totalMeetingRooms = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Meeting Rooms Creating!");

            for (int i = 1; i <= totalMeetingRooms; i++)
            {
                Console.WriteLine($"How many seats for M{i:D3}");
                int meetingRoomSeatCapacity = Convert.ToInt32(Console.ReadLine());
                MeetingRoom meetingRoom = new MeetingRoom
                {
                    FacilityId = facilityId,
                    MeetingRoomCode = $"M{i:D3}",
                    TotalSeats = meetingRoomSeatCapacity,
                };
                
                
                meetingRoomId = await meetingRoomManager.Add(meetingRoom);
                

                //take this meetingRoomId, create new Meeting Room Assets till needed
                do
                {
                    assetId = await assetManagerView.CreateOrAddExistingAssetView();

                    if (assetId != 0)
                    {
                        Console.Write($"How many of these assets do you need for M{i:D3}?:");

                        int assetQty = Convert.ToInt32(Console.ReadLine());

                        MeetingRoomAssets meetingRoomAssets = new MeetingRoomAssets { AssetId = assetId, MeetingRoomId = meetingRoomId, NoOfItems = assetQty };

                        await meetingRoomAssetsManager.Add(meetingRoomAssets);
                    }

                } while (assetId!=0);
            }
        }
    }
}
