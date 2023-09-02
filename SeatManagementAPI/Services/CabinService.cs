using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    public class CabinService : ICabinService
    {
        private readonly IRepository<Cabin> _cabinRepository;

        public CabinService(IRepository<Cabin> cabinRepository)
        {
            _cabinRepository = cabinRepository;
        }

   
        public Cabin[] GetAllCabins()
        {
            return _cabinRepository.GetAll();
        }

   
        public void AddCabin(CabinDTO cabin)
        {
            _cabinRepository.Add(new Cabin { CabinCode = cabin.CabinCode, EmployeeId = null, FacilityId = cabin.FacilityId });
        }


        public Cabin GetCabinById(int id)
        {
            return _cabinRepository.GetById(id);
        }

   
        public void EditCabin(Cabin cabin)
        {
            var originalCabin = _cabinRepository.GetById(cabin.FacilityId);
            if (originalCabin == null) { throw new Exception("Not Found Cabin"); }

            originalCabin.CabinCode = cabin.CabinCode;
            originalCabin.EmployeeId = cabin.EmployeeId;
            originalCabin.FacilityId = cabin.FacilityId;

            _cabinRepository.Update(originalCabin);
        }

  
        public void DeleteById(int id)
        {
            _cabinRepository.DeleteById(id);
        }

        public void CabinAllocate(int cabinId, int employeeId)
        {
            var cabin = _cabinRepository.GetById(cabinId);
            cabin.EmployeeId = employeeId;
        }

        public void CabinDeallocate(int cabinId)
        {
            var cabin = _cabinRepository.GetById(cabinId);
            cabin.EmployeeId = null;
            cabin.Employee = null;
        }

        public void AddManyCabins(int totalCabins, int facilityId)
        {
            List<Cabin> emptyCabins = new List<Cabin>();
            for (int i = 1; i <= totalCabins; i++)
            {

                Cabin emptyCabin = new Cabin
                {
                    FacilityId = facilityId,
                    CabinCode = $"C{i:D3}"
                };
                emptyCabins.Add(emptyCabin);
            }

            _cabinRepository.AddMany(emptyCabins);
        }
    }

}
