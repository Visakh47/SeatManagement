using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IEntityManager<T>
    {
        Task<int> Add(T entity);
        Task<List<T>> GetAll();
        void AddMany(string extension);
    }
}
