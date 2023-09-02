using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cityService.GetAllCities());
        }

        [HttpPost]

        public IActionResult Add(CityDTO city) {
            int id = _cityService.AddCity(city);
            return Ok(id);
        }

       
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cityService.GetCityById(id));
        }

        [HttpPut]
        public IActionResult Edit(City city) {
            _cityService.EditCity(city);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id) {
            _cityService.DeleteCityById(id);
            return Ok(); 
        }
    }
}
