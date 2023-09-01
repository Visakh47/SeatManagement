using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;

namespace SeatManagementAPI.Controllers
{

    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public City[] GetAllCities()
        {
            return _cityRepository.GetAll();
        }

        public void AddCity(CityDTO city) {
            _cityRepository.Add(new City { CityName = city.CityName, CityAbbreviation = city.CityAbbreviation });
        }


        public City GetCityById(int id)
        {
            return _cityRepository.GetById(id);
        }

     
        public void EditCity(City city) {
            var originalCity = _cityRepository.GetById(city.CityId);
            if(originalCity == null) { throw new Exception("Not Found City"); }

            originalCity.CityName = city.CityName;
            originalCity.CityAbbreviation = city.CityAbbreviation;

            _cityRepository.Update(originalCity); 
        }

       
        public void DeleteCityById(int id) {  
            _cityRepository.DeleteById(id);
        }
    }
}
