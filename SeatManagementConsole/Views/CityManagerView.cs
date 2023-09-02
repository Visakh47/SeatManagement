using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Views
{
    public class CityManagerView
    {
        IEntityManager<City> cityManager;
        public CityManagerView(IEntityManager<City> cityManager)
        {
            this.cityManager = cityManager;    
        }
        public async Task<int> CreateOrAddExistingCityView() {
            Console.WriteLine("1.Add to existing city\n2.Add to new city"); 
            Console.Write("Enter your option:"); 
            int op2 = Convert.ToInt32(Console.ReadLine());
            var cityId = 0; var buildingId = 0; 
            if (op2 == 1) 
            { 
                var cityList = await cityManager.GetAll(); 
                foreach (var city in cityList) 
                { 
                    Console.WriteLine($"{city.CityId}. {city.CityName}");
                } 
                Console.Write("Enter the city Id of the city you want: ");
                cityId = Convert.ToInt32(Console.ReadLine());
                
            }
            else if (op2 == 2) 
            { 
                Console.Write("Enter the name of city: ");
                var cityName = Console.ReadLine(); 
                Console.WriteLine("Enter a city abbreviation: "); 
                var cityAbbreviation = Console.ReadLine(); 
                var cityObj = new City { CityName = cityName, CityAbbreviation = cityAbbreviation }; 
                cityId = await cityManager.Add(cityObj);
                
            }
            return cityId;
        }
    }
}
