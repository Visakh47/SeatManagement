using SeatManagementAPI.Models.DTO;
using SeatManagementAPI.Models;

public interface IFacilityService
{
    Facility[] GetAllFacilities();
    int AddFacility(FacilityDTO facility);
    Facility GetFacilityById(int id);
    void EditFacility(Facility facility);
    void DeleteFacilityById(int id);
}
