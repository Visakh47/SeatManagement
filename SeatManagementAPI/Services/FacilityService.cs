using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;
using SeatManagementAPI.Custom_Exceptions;

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


    public int AddFacility(FacilityDTO facility)
    {
        Facility fac = new Facility
        {
            FacilityName = facility.FacilityName,
            FacilityFloor = facility.FacilityFloor,
            BuildingId = facility.BuildingId,
            CityId = facility.CityId,
        };
        _facilityRepository.Add(fac);
        return fac.FacilityId;
    }


    public Facility GetFacilityById(int id)
    {
        var facility = _facilityRepository.GetById(id);
        if (facility == null)
            throw new FacilityNotFoundException(id);
        else
            return facility;
    }

 
    public void EditFacility(Facility facility)
    {
        try
        {
            var originalFacility = _facilityRepository.GetById(facility.FacilityId);
            if (originalFacility == null)
            {
                throw new FacilityNotFoundException(facility.FacilityId);
            }

            originalFacility.FacilityName = facility.FacilityName;

            _facilityRepository.Update(originalFacility);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public void DeleteFacilityById(int id)
    {
        _facilityRepository.DeleteById(id);
    }
}
