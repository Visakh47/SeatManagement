using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Interfaces
{
    public interface ICityService
    {
        void DeleteCityById(int id);
        void EditCity(City city);
        City GetCityById(int id);
        int AddCity(CityDTO city);
        City[] GetAllCities();
    }
}
