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
        IEntityManager<Building> buildingManager = new EntityManager<Building>("buildings");
        IEntityManager<Seat> seatManager = new EntityManager<Seat>("Seat");
        IEntityManager<Cabin> cabinManager = new EntityManager<Cabin>("Cabin");
        IEntityManager<Seat> meetingRoomManager = new EntityManager<Seat>("MeetingRoom");
        IReportManager<UnAllocatedView> uaReportManager = new ReportManager<UnAllocatedView>("Report/deallocatedList");
        IReportManager<Overview> aReportManager = new ReportManager<Overview>("Report/allocatedList");
        FacilityManagerView facilityManagerView = new FacilityManagerView(facilityManager);
        CityManagerView cityManagerView = new CityManagerView(cityManager);
        BuildingManagerView buildingManagerView = new BuildingManagerView(buildingManager);
        SeatManagerView seatManagerView = new SeatManagerView(seatManager);
        CabinManagerView cabinManagerView = new CabinManagerView(cabinManager);
        MeetingRoomManagerView meetingRoomManagerView = new MeetingRoomManagerView(meetingRoomManager);
        IReportManagerView<UnAllocatedView> unAllocatedReportManagerView = new UnAllocatedReportManagerView<UnAllocatedView>(uaReportManager);
        IReportManagerView<Overview> allocatedReportManagerView = new AllocatedReportManagerView<Overview>(aReportManager);



        IAllocationManager<Seat> seatAllocationManager = new AllocationManager<Seat>("Seat");

        Console.WriteLine("Welcome!");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("\t\tSEAT ALLOCATION SOFTWARE\t\t");
        Console.WriteLine("---------------------------------------------------------\n\n");

        do
        {


            Console.WriteLine("***************************************************");
            Console.WriteLine("                  MAIN MENU");
            Console.WriteLine("***************************************************\n");
            Console.WriteLine("1.Onboard Facility\n2.Onboard Seats\n3.Add Employees\n4.Seat Allocation\n5.Seat Deallocation\n6.Report Generation\n");
            Console.WriteLine("***************************************************");
            Console.Write("Choose your option: ");
            int op1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("***************************************************");

            switch (op1)
            {
                case 1:
                    {

                        int facilityId = await facilityManagerView.CreateFacilityView();
                        seatManagerView.AddBulkSeatsView(facilityId);
                        cabinManagerView.AddBulkCabinsView(facilityId);
                        meetingRoomManagerView.AddBulkMeetingRoomView(facilityId);
                        break;
                    }

                case 2:
                    {
                        //Have to create a input provider for this facilityId;
                        Console.Write("Enter a Facility Where You Wish To Onboard Seats?");
                        int facilityId = Convert.ToInt32(Console.ReadLine());
                        seatManagerView.AddBulkSeatsView(facilityId);
                        break;
                    }

                case 3:
                    {
                        //have to create EmployeeManagerView
                        break;
                    }

                case 4:
                    {
                        seatManagerView.AllocateSeatView();
                        break;
                    }

                case 5:
                    {
                        seatManagerView.DeAllocateSeatView();
                        break;
                    }

                case 6:
                    {
                        //Have to create ReportManagerView
                        unAllocatedReportManagerView.Display();
                        allocatedReportManagerView.Display();
                        break;
                    }


            }

            Console.WriteLine("***************************************************");
            Console.WriteLine("\n\n\t\tGoing Back To Menu\n\n");
            Console.WriteLine("***************************************************");

        } while (true);

        }
}

