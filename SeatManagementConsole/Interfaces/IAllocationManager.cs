using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IAllocationManager<T> 
    {
        public void Allocate(int entityId, int employeeId);
        public void DeAllocate(int entityId);
    }
}
