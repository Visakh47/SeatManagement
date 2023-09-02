using SeatManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Managers
{
    public class AllocationManager<T> : IAllocationManager<T> where T : class
    {
        public void Allocate(int entityId, int employeeId)
        {
            throw new NotImplementedException();
        }

        public void DeAllocate(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
