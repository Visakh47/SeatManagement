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
        private readonly IRepository<Employee> _employeeRepository;

        public CabinService(IRepository<Cabin> cabinRepository, IRepository<Employee> employeeRepository)
        {
            _cabinRepository = cabinRepository;
            _employeeRepository = employeeRepository;
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
            if (cabin.Employee == null)
            {
                Employee e = _employeeRepository.GetById(employeeId);
                cabin.Employee = e;
                cabin.Employee.isAllocated = true;
                _employeeRepository.Update(e);
            }
            _cabinRepository.Update(cabin);
        }

        public void CabinDeallocate(int cabinId)
        {
            var cabin = _cabinRepository.GetById(cabinId);
            if (cabin.Employee != null)
            {
                Employee e = _employeeRepository.GetById(cabin.Employee.EmployeeId);
                cabin.Employee = e;
                cabin.Employee.isAllocated = false;
                _employeeRepository.Update(e);
            }
            cabin.EmployeeId = null;
            cabin.Employee = null;
            _cabinRepository.Update(cabin);
        }

        public void AddManyCabins(int totalCabins, int facilityId)
        {
            List<Cabin> emptyCabins = new List<Cabin>();
            int cabinCount = _cabinRepository.GetAll().Where(x => x.FacilityId == facilityId).ToList().Count();
            for (int i = cabinCount+1; i <= totalCabins+cabinCount; i++)
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
