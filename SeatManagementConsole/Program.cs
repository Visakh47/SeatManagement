using Newtonsoft.Json;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementConsole;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    
    

    public static void Main(string[] args)
    {
        Test().Wait();
    }

    public static async Task Test() {
        //AddBuilding().Wait();
        //await GetAllBuildings();

        //await AddObject<City>(new City { CityName = "Kochi", CityAbbreviation = "COK" }, "City");

        APIService CityAPI = new APIService("City");
        List<City> Cities = await CityAPI.GetAll<City>();

        foreach (var city in Cities)
        {
            Console.WriteLine($"City-Id:{city.CityId}");
            Console.WriteLine($"City-Name:{city.CityName}");
            Console.WriteLine($"City-Abbreviation:{city.CityAbbreviation}");
        }

        City c = await CityAPI.GetById<City>(2);

        Console.WriteLine($"City-Id:{c.CityId}");
        Console.WriteLine($"City-Name:{c.CityName}");
        Console.WriteLine($"City-Abbreviation:{c.CityAbbreviation}");

        Thread.Sleep(500000);
    }
}

