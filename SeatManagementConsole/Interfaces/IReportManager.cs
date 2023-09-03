using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IReportManager<T>
    {
        Task<List<T>> GetAll();
    }
}
