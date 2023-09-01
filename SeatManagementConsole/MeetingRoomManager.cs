using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class MeetingRoomManager<T> : IResourceManager<T> where T : class
    {
        IAPIService MeetingRoomAPI;
        public MeetingRoomManager(string apiEndPoint)
        {
            MeetingRoomAPI = new APIService(apiEndPoint);   
        }
        public async void Add(T entity)
        {
            await MeetingRoomAPI.Post(entity);
        }

        public void Allocate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
