using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Interfaces
{
    public interface ICabinService
    {
        Cabin[] GetAllCabins();
        void AddCabin(CabinDTO cabin);
        Cabin GetCabinById(int id);
        void EditCabin(Cabin cabin);
        void DeleteById(int id);
    }
}
