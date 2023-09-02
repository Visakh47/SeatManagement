using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeatManagementConsole.Interfaces;

namespace SeatManagementConsole.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : class
    {
        private readonly APIService<T> _entityAPICall;
        public EntityManager(string apiEndPoint)
        {
            _entityAPICall = new APIService<T>(apiEndPoint);
        }
        public async void Add(T entity)
        {
            await _entityAPICall.Post(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _entityAPICall.GetAll<T>();
        }
    }
}
