using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using System.ComponentModel;

public class UnAllocatedReportManagerView<T> : IReportManagerView<T> 
{
    private readonly IReportManager<UnAllocatedView> uaReportManager;

    public UnAllocatedReportManagerView(IReportManager<UnAllocatedView> uaReportManager)
    {
        this.uaReportManager = uaReportManager;
    }
    public async void Display() {
        var unAllocatedSeatReports = uaReportManager.GetAll().Result;

        Console.WriteLine("List of Unallocated Seats:");
        Console.WriteLine("Seat Id. City Abbreviation - Building Abbreviation - FacilityFloor - FacilityName - SeatCode\n");
        foreach (var report in unAllocatedSeatReports)
        {
            Console.WriteLine($"{report.SeatId}. {report.CityAbbreviation} - {report.BuildingAbbreviation} - {report.FacilityFloor} - {report.FacilityName} - {report.SeatCode}");
        } 
    }

    public async Task GenerateReport()
    {
        
        var unAllocatedSeats = uaReportManager.GetAll().Result;

        IEntityManager<Building> buildingManager = new EntityManager<Building>("Buildings");
        IEntityManager<City> cityManager = new EntityManager<City>("City");

        var cityList = cityManager.GetAll().Result; 
        var buildingList = buildingManager.GetAll().Result;

        IFacilityManager facilityManager = new FacilityManager("Facility");
        var facilityList = await facilityManager.GetAllFacilities();


        Console.WriteLine("Filtering Menu For Report:");

        //have to do filtering by cabin

        Console.WriteLine("1.By Facility Name\n2.By Building & Floor\n3.By Seats\n");
        Console.Write("Enter your option here:");
        var op4 = Convert.ToInt32(Console.ReadLine());
        if (op4 == 1)
        {
            Console.WriteLine("Facility List:");
            foreach (Facility facility in facilityList)
            {
                Console.WriteLine($"{facility.FacilityId}. {facility.City.CityAbbreviation}-{facility.Building.BuildingAbbreviation}-{facility.FacilityFloor}-{facility.FacilityName}");
            }
            Console.Write("Enter the Facility Name: ");
            var facilityName = Console.ReadLine();
            var filteredSeats = unAllocatedSeats.Where(x => x.FacilityName.Equals(facilityName)).ToList();
           

            Console.WriteLine($"Unallocated Seats in {facilityName}");
            foreach (var seat in filteredSeats)
            {
                Console.WriteLine($"{seat.SeatId}. {seat.CityAbbreviation}-{seat.BuildingAbbreviation}-{seat.FacilityFloor}-{seat.FacilityName}-{seat.SeatCode}");
            }
        }

       

        else if (op4 == 2)
        {
            
            Console.WriteLine("Building List:");
            foreach (Facility facility in facilityList)
            {
                Console.WriteLine($"{facility.Building.BuildingId}. {facility.Building.BuildingName} - {facility.Building.BuildingAbbreviation} - {facility.FacilityFloor}");
            }
            Console.Write("Enter the Building Abbreviation for filtering: ");
            var buildingAbbreviation = Console.ReadLine();
            Console.Write("Enter the floor number by which you want to search: ");
            var floorNo = Convert.ToInt16(Console.ReadLine());

            var filteredSeats = unAllocatedSeats.Where(x => x.FacilityFloor == floorNo && x.BuildingAbbreviation.Equals(buildingAbbreviation)).ToList();


            Console.WriteLine("List of Unallocated Seats in {facilityName} & {floorNo}:");
            foreach (var unallo in filteredSeats)
            {
                Console.WriteLine($"{unallo.SeatId}. {unallo.CityAbbreviation} - {unallo.BuildingAbbreviation}  -  {unallo.FacilityFloor}  -  {unallo.FacilityName}  -  {unallo.SeatCode}");
            }

        }

        else if (op4 == 3)
        {
            Display();
        }
    }

}