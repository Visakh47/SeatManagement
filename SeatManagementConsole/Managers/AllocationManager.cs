﻿using SeatManagementAPI.Models;
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
            string extension = $"/{entityId}?EmployeeId={employeeId}";
            _allocationAPI.PatchWithExtension<T>(extension);
        }

        public async void DeAllocate(int entityId)
        {
            string extension = $"/{entityId}";
            _allocationAPI.PatchWithExtension<T>(extension);
        }
    }
}
