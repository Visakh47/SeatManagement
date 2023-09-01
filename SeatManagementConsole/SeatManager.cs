using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class SeatManager<T>: IResourceManager<T> where T : class
    {
        IAPIService SeatAPI;
        public SeatManager(string apiEndPoint)
        {
            SeatAPI = new APIService(apiEndPoint);
        }
        public async void Add(T entity)
        {
            await SeatAPI.Post(entity);
        }

        public void Allocate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
