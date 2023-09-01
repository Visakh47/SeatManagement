using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public class FacilityService : IFacilityService
{
    private readonly IRepository<Facility> _facilityRepository;

    public FacilityService(IRepository<Facility> facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }


    public Facility[] GetAllFacilities()
    {
        return _facilityRepository.GetAll();
    }


    public void AddFacility(FacilityDTO facility)
    {
        _facilityRepository.Add(new Facility 
        { FacilityName = facility.FacilityName, 
          FacilityFloor = facility.FacilityFloor,
          BuildingId = facility.BuildingId,
          CityId = facility.CityId,
        });
    }


    public Facility GetFacilityById(int id)
    {
        return _facilityRepository.GetById(id);
    }

 
    public void EditFacility(Facility facility)
    {
        var originalFacility = _facilityRepository.GetById(facility.FacilityId);
        if (originalFacility == null)
        {
            throw new Exception("Not Found Facility");
        }

        originalFacility.FacilityName = facility.FacilityName;

        _facilityRepository.Update(originalFacility);
    }


    public void DeleteFacilityById(int id)
    {
        _facilityRepository.DeleteById(id);
    }
}
