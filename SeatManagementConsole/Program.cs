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
        IEntityManager<Seat> seatManager = new EntityManager<Seat>("Seat");
        IEntityManager<Cabin> cabinManager = new EntityManager<Cabin>("Cabin");
        IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
        IEntityManager<MeetingRoom> meetingRoomManager = new EntityManager<MeetingRoom>("MeetingRoom");
        IEntityManager<Asset> assetManager = new EntityManager<Asset>("Asset");

        IReportManager<SeatUnAllocatedView> suaReportManager = new ReportManager<SeatUnAllocatedView>("Report/seatdeallocatedList");
        IReportManager<SeatOverview> saReportManager = new ReportManager<SeatOverview>("Report/seatallocatedList");
        IReportManager<CabinUnAllocatedView> cuaReportManager = new ReportManager<CabinUnAllocatedView>("Report/cabindeallocatedList");
        IReportManager<CabinOverview> caReportManager = new ReportManager<CabinOverview>("Report/cabinallocatedList");
        FacilityManagerView facilityManagerView = new FacilityManagerView(facilityManager);

        SeatManagerView seatManagerView = new SeatManagerView(seatManager);
        CabinManagerView cabinManagerView = new CabinManagerView(cabinManager);
        AssetManagerView assetManagerView = new AssetManagerView(assetManager);

        EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);

        MeetingRoomManagerView meetingRoomManagerView = new MeetingRoomManagerView(meetingRoomManager);
        IReportManagerView unAllocatedReportManagerView = new UnAllocatedReportManagerView(suaReportManager,cuaReportManager);
        IReportManagerView allocatedReportManagerView = new AllocatedReportManagerView(saReportManager, caReportManager);




        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("\t\tSEAT ALLOCATION SOFTWARE\t\t");
        Console.WriteLine("---------------------------------------------------------\n\n");

        do
        {


            Console.WriteLine("***************************************************");
            Console.WriteLine("                  MAIN MENU");
            Console.WriteLine("***************************************************\n");
            Console.WriteLine("1.Onboard Facility\n2.Onboard Seats\n3.Add Employees\n4.Seat Allocation\n5.Seat Deallocation\n6.Cabin Allocation\n7.Cabin Deallocation\n8.Report Generation\n9. Exit\n");
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
                        await meetingRoomManagerView.AddBulkMeetingRoomView(facilityId);
                        break;
                    }

                case 2:
                    {
                        await facilityManagerView.AllFacilitiesView();
                        //Have to create a input provider for this facilityId;
                        Console.Write("Enter a Facility Where You Wish To Onboard Seats?");
                        int facilityId = Convert.ToInt32(Console.ReadLine());
                        seatManagerView.AddBulkSeatsView(facilityId);
                        break;
                    }

                case 3:
                    {
                        employeeManagerView.CreateMultipleView();
                        break;
                    }

                case 4:
                    {
                        await seatManagerView.AllocateSeatView();
                        break;
                    }

                case 5:
                    {
                        await seatManagerView.DeAllocateSeatView();
                        break;
                    }

                case 6: {
                        await cabinManagerView.AllocateCabinView();
                        break;
                    }

                case 7: {
                        await cabinManagerView.DeAllocateCabinView();
                        break;
                    }

                case 8:
                    {
                        await unAllocatedReportManagerView.GenerateReportView();
                        break;
                    }

                case 9: {
                        System.Environment.Exit(0);
                        break;
                    }

                default: {
                        Console.WriteLine("Break");
                        break;
                    }


            }

            Console.WriteLine("***************************************************");
            Console.WriteLine("\n\n\t\tGoing Back To Menu\n\n");
            Console.WriteLine("***************************************************");

        } while (true);

        }
}

