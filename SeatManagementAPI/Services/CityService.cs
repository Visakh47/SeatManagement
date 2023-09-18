using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Custom_Exceptions;
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

        public int AddCity(CityDTO city) {
            City c = new City { CityName = city.CityName, CityAbbreviation = city.CityAbbreviation };
            _cityRepository.Add(c);
            return c.CityId;
        }


        public City GetCityById(int id)
        {
            try
            {
                var city = _cityRepository.GetById(id);
                if (city == null)
                    throw new CityNotFoundException(id);
                else
                    return city;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

     
        public void EditCity(City city) {
            try
            {
                var originalCity = _cityRepository.GetById(city.CityId);
                if (originalCity == null) { throw new CityNotFoundException(city.CityId); }

                originalCity.CityName = city.CityName;
                originalCity.CityAbbreviation = city.CityAbbreviation;

                _cityRepository.Update(originalCity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public void DeleteCityById(int id) {  
            _cityRepository.DeleteById(id);
        }
    }
}
