using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    public interface IFacilityManager
    {
        Task<int> OnBoardFacility(Facility facility);
        Task<List<Facility>> GetAllFacilities();
    }
}
