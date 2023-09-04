using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Managers
{
    public class FacilityManager : IFacilityManager
    {
        IAPIService<Facility> _facilityAPI;
        public FacilityManager(string apiEndpoint)
        {
            //Generating the API Service 
            _facilityAPI = new APIService<Facility>(apiEndpoint);

        }

        public async Task<List<Facility>> GetAllFacilities()
        {
            return await _facilityAPI.GetAll<Facility>();
        }

        public async Task<int> OnBoardFacility(Facility facility)
        {
            return (int)await _facilityAPI.Post(facility);
        }
    }
}
