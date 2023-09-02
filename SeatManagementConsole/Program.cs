using Newtonsoft.Json;
using SeatManagementAPI.Models;
using SeatManagementAPI.Models.DTO;
using SeatManagementConsole;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using SeatManagementConsole.Views;
using System;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        UI().Wait();
    }

    //this is static for the timebeing - will create a different provider for UI to be only called Once
    public static async Task UI()
    {
        IFacilityManager facilityManager = new FacilityManager("Facility");
        IEntityManager<City> cityManager = new EntityManager<City>("City");
        IEntityManager<Building> buildingManager = new EntityManager<Building>("Building");
        IEntityManager<Seat> seatManager = new EntityManager<Seat>("Seat");
        IEntityManager<Cabin> cabinManager = new EntityManager<Cabin>("Cabin");
        IEntityManager<Seat> meetingRoomManager = new EntityManager<Seat>("MeetingRoom");
        FacilityManagerView facilityManagerView = new FacilityManagerView(facilityManager);
        CityManagerView cityManagerView = new CityManagerView(cityManager);
        BuildingManagerView buildingManagerView = new BuildingManagerView(buildingManager);
        SeatManagerView seatManagerView = new SeatManagerView(seatManager);
        CabinManagerView cabinManagerView = new CabinManagerView(cabinManager);
        MeetingRoomManagerView meetingRoomManagerView = new MeetingRoomManagerView(meetingRoomManager);

        IAllocationManager<Seat> seatAllocationManager = new AllocationManager<Seat>("Seat");
        Console.WriteLine("Welcome!");
        Console.WriteLine("SEAT ALLOCATION SOFTWARE");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("MENU");
        Console.WriteLine("1.Onboard Facility\n2.Onboard Seats\n3.Add Employees\n4.Seat Allocation\n5.Seat Deallocation\n6.Report Generation");
        Console.Write("Choose your option: "); 
        int op1 = Convert.ToInt32(Console.ReadLine());

        switch (op1)
        {
            case 1: {
                    
                    int facilityId = await facilityManagerView.CreateFacilityView();
                    seatManagerView.AddBulkSeatsView(facilityId);
                    cabinManagerView.AddBulkCabinsView(facilityId);
                    meetingRoomManagerView.AddBulkMeetingRoomView(facilityId);
                    break;
            }

          case 2:
                {
                    //Have to create a input provider for this facilityId;
                    int facilityId = 1;
                    seatManagerView.AddBulkSeatsView(facilityId);
                    break;
                }

            case 3:
                {
                    //have to create EmployeeManagerView
                    break;
                }

            case 4: {
                    seatManagerView.AllocateSeatView();
                    break;
                }

            case 5: {
                    seatManagerView.DeAllocateSeatView();
                    break;
                }

            case 6: {
                    //Have to create ReportManagerView
                    break;
                }
            

        }

        }
}

