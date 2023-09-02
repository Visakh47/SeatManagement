using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<Building> _buildingRepository;

        public BuildingService(IRepository<Building> buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }


        public Building[] GetAllBuildings()
        {
            return _buildingRepository.GetAll();
        }

      
        public int AddBuilding(BuildingDTO building)
        {
            Building b = new Building
            {
                BuildingName = building.BuildingName,
                BuildingAbbreviation = building.BuildingAbbreviation
            };
            _buildingRepository.Add(b);
            return b.BuildingId;
        }

 
        public Building GetBuildingById(int id)
        {
            return _buildingRepository.GetById(id);
        }


        public void EditBuilding(Building building)
        {
            var originalBuilding = _buildingRepository.GetById(building.BuildingId);
            if (originalBuilding == null) {  throw new Exception("Building doesn't exist"); }

            originalBuilding.BuildingName = building.BuildingName;
            originalBuilding.BuildingAbbreviation = building.BuildingAbbreviation;

            _buildingRepository.Update(originalBuilding);
        }

    
        public void DeleteBuildingById(int id)
        {
            _buildingRepository.DeleteById(id);
        }
    }

}
