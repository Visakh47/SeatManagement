using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class CabinManager<T> : IResourceManager<T> where T:class
    {
        IAPIService CabinAPI;
        public CabinManager(string apiEndPoint)
        {
            CabinAPI = new APIService(apiEndPoint);
        }
        public async void Add(T entity)
        {
            await CabinAPI.Post(entity);
        }

        public void Allocate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
