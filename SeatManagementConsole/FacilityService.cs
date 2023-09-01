using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class FacilityService : IFacilityService
    {
        IAPIService FacilityAPI;
        public FacilityService(string apiEndpoint) {
            //Generating the API Service 
            FacilityAPI = new APIService(apiEndpoint);
        }
        public void OnBoardFacility(Facility facility)
        {
            FacilityAPI.Post(facility);
        }
    }
}
