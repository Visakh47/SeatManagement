using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IEntityManager<T>
    {
        void Add(T entity);
        Task<List<T>> GetAll();
    }
}
