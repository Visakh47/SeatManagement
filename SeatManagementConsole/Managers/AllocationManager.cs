using SeatManagementAPI.Models;
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
        private readonly string _apiEndPoint;
        public IAPIService<T> _allocationAPI;
        public AllocationManager(string apiEndPoint)
        {
            _apiEndPoint = apiEndPoint;
            _allocationAPI = new APIService<T>(_apiEndPoint);
        }
        public async void Allocate(int entityId, int employeeId)
        {
            string extension = $"/allocate?{_apiEndPoint.ToLower()}Id={entityId}&EmployeeId={employeeId}";
            _allocationAPI.PutWithExtension<T>(extension);
        }

        public async void DeAllocate(int entityId)
        {
            string extension = $"/deallocate?{_apiEndPoint.ToLower()}Id={entityId}";
            _allocationAPI.PutWithExtension<T>(extension);
        }
    }
}
