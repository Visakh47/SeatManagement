using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public interface IFacilityService
    {
        public void OnBoardFacility(Facility facility);
    }
}
