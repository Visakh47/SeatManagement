using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IRepository<City> _cityRepository;

        public CityController(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cityRepository.GetAll());
        }

        [HttpPost]

        public IActionResult Add(CityDTO city) {
            _cityRepository.Add(new City { CityName = city.CityName, CityAbbreviation = city.CityAbbreviation });
            return Ok();
        }

       
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cityRepository.GetById(id));
        }

        [HttpPut]
        public IActionResult Edit(City city) {
            var originalCity = _cityRepository.GetById(city.CityId);
            if(originalCity == null) { return NotFound(); }

            originalCity.CityName = city.CityName;
            originalCity.CityAbbreviation = city.CityAbbreviation;

            _cityRepository.Update(originalCity);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id) {  
            _cityRepository.DeleteById(id);
            return Ok(); 
        }
    }
}
