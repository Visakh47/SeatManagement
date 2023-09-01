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

        //APIService CityAPI = new APIService("City");
        //List<City> Cities = await CityAPI.GetAll<City>();

        //foreach (var city in Cities)
        //{
        //    Console.WriteLine($"City-Id:{city.CityId}");
        //    Console.WriteLine($"City-Name:{city.CityName}");
        //    Console.WriteLine($"City-Abbreviation:{city.CityAbbreviation}");
        //}

        //City c = await CityAPI.GetById<City>(2);

        //Console.WriteLine($"City-Id:{c.CityId}");
        //Console.WriteLine($"City-Name:{c.CityName}");
        //Console.WriteLine($"City-Abbreviation:{c.CityAbbreviation}");

        //Thread.Sleep(500000);

        Console.WriteLine("Welcome!");

        Console.WriteLine("1.Onboard A Facility");

        Console.WriteLine("Onboarding Facility");
        Console.WriteLine("Enter Details:");


        //    public int CityId { get; set; }
        //public int BuildingId { get; set; }
        //public int FacilityFloor { get; set; }
        //public string FacilityName { get; set; }


        Console.WriteLine("Which City Does The Facility Belong To?");
        //Display all cities
        var cityId = Console.ReadLine();
        Console.WriteLine("Which Building Does The Facility Belong To?");
        var buildingId = Console.ReadLine();
        Console.WriteLine("Which Floor hosts the Facility?");
        var floorNumber = Console.ReadLine();
        Console.WriteLine("What Is The Name Of The Facility?");
        var facilityName = Console.ReadLine();
        //Creating a Facility Object

        Facility facility = new Facility
        { 
            FacilityName = facilityName,
            FacilityFloor = Convert.ToInt32(floorNumber),
            BuildingId = Convert.ToInt32(buildingId),
            CityId = Convert.ToInt32(cityId),
        };

        Console.WriteLine("How many no of seats do you need?");

        



    }
}

