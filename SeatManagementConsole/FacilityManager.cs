using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class FacilityManager : IFacilityManager
    {
        IAPIService FacilityAPI;
        public FacilityManager(string apiEndpoint) {
            //Generating the API Service 
            FacilityAPI = new APIService(apiEndpoint);
        }
        public async Task<int> OnBoardFacility(Facility facility)
        {
            return (int) await FacilityAPI.Post(facility); 
        }
    }
}
