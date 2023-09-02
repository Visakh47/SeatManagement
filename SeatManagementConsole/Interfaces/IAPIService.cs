using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IAPIService<T>
    {
        Task<int?> Post<T>(T newObject);
        Task<int?> PostMany<T>(T newObject, string extension);

        Task<List<T>> GetAll<T>();
        Task<T> GetById<T>(int id);
        Task Put<T>(T Object);
    }
}
