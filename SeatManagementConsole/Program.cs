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


        Console.WriteLine("Which City Does The Facility Belong To?");
        //Display all cities
        var cityId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Which Building Does The Facility Belong To?");
        //Display all builings
        var buildingId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Which Floor hosts the Facility?");
        var floorNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What Is The Name Of The Facility?");
        var facilityName = Console.ReadLine();
        //Creating a Facility Object

        Facility facility = new Facility
        {
            FacilityName = facilityName,
            FacilityFloor = floorNumber,
            BuildingId =buildingId,
            CityId = cityId,
        };

        
        

        IFacilityGenerator facilityGenerator = new FacilityGenerator("Facility");
        facilityGenerator.OnBoardFacility(facility);

        Console.WriteLine($"{facility.FacilityId} created!"); //error here


        Console.WriteLine("How many number of seats does the facility have?");
        var totalSeats = Convert.ToInt32(Console.ReadLine());

      
        //Creating Bulk Seats

        Console.WriteLine("Seats Creating!");

        IResourceManager<Seat> seatManager = new SeatManager<Seat>("Seat");

        for(int i = 1;i<= totalSeats; i++) {
            Seat emptySeat = new Seat
            {
                FacilityId = facility.FacilityId,
                SeatCode = $"S{i:D3}"
            };
            seatManager.Add(emptySeat);
        }

        Console.WriteLine("How many number of cabins does the facility have?");
        var totalCabins = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Cabins Creating!");

        IResourceManager<Cabin> cabinManager = new CabinManager<Cabin>("Cabin");

        for (int i = 1; i <= totalCabins; i++)
        {
            Cabin emptyCabin = new Cabin
            {
                FacilityId = facility.FacilityId,
                CabinCode = $"C{i:D3}"
            };
            cabinManager.Add(emptyCabin);
        }

        Console.WriteLine("How many number of Meeting Rooms does the facility have?");
        var totalMeetingRooms = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Meeting Rooms Creating!");

        IResourceManager<MeetingRoom> meetingRoomManager = new MeetingRoomManager<MeetingRoom>("MeetingRoom");

        for (int i = 1; i <= totalMeetingRooms; i++)
        {
            Console.WriteLine($"How many seats for M{i:D3}");
            int meetingRoomSeatCapacity = Convert.ToInt32(Console.ReadLine());
            MeetingRoom meetingRoom = new MeetingRoom
            {
                FacilityId = facility.FacilityId,
                MeetingRoomCode = $"M{i:D3}",
                TotalSeats = meetingRoomSeatCapacity
            };
            meetingRoomManager.Add(meetingRoom);
        }

        Console.WriteLine("Succesfully Created A New Facility!");

        Console.ReadLine();
    }
}

