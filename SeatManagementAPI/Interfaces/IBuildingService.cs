using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Interfaces
{
    public interface IBuildingService
    {
        Building[] GetAllBuildings();
        void AddBuilding(BuildingDTO building);

        Building GetBuildingById(int id);

        void EditBuilding(Building building);

        void DeleteBuildingById(int id);

    }
}
