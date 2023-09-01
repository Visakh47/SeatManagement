using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
 

    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly IRepository<Cabin> _cabinRepository;

        public CabinController(IRepository<Cabin> cabinRepository)
        {
            _cabinRepository = cabinRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cabinRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(CabinDTO cabin)
        {
            _cabinRepository.Add(new Cabin { CabinCode = cabin.CabinCode, EmployeeId = cabin.EmployeeId, FacilityId = cabin.FacilityId });
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cabinRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(Cabin cabin)
        {
            var originalCabin = _cabinRepository.GetById(cabin.FacilityId);
            if (originalCabin == null) { return NotFound(); }

            originalCabin.CabinCode = cabin.CabinCode;
            originalCabin.EmployeeId = cabin.EmployeeId;
            originalCabin.FacilityId = cabin.FacilityId;

            _cabinRepository.Update(originalCabin);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cabinRepository.DeleteById(id);
            return Ok();
        }
    }

}
