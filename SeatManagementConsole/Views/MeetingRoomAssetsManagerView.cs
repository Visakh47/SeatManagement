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
    public class MeetingRoomAssetsManagerView
    {
        
        private readonly IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager;
       

        public MeetingRoomAssetsManagerView(IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager)
        {
            meetingRoomAssetsManager = meetingRoomAssetsManager;
            
        }

        

    }
}
