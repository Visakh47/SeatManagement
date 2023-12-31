﻿using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Views
{
    public class SeatManagerView
    {
        IEntityManager<Seat> seatManager;
        public SeatManagerView(IEntityManager<Seat> seatManager)
        {
            this.seatManager = seatManager;
        }

        public async void AddBulkSeatsView(int facilityId)
        {

            Console.Write("How many number of seats does the facility require: ");
            var totalSeats = Convert.ToInt32(Console.ReadLine());

            string extension = $"?FacilityId={facilityId}&totalSeats={totalSeats}";
            try
            {
                seatManager.AddMany(extension);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task AllocateSeatView()
        {
            IReportManager<SeatUnAllocatedView> suaReportManager = new ReportManager<SeatUnAllocatedView>("Report/seatdeallocatedList");
            IReportManagerView unAllocatedReportManagerView = new UnAllocatedReportManagerView(suaReportManager,null);
            IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
            EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);

            //List of unallocated employees to be shown here:
            await employeeManagerView.ListUnAllocatedEmployeesView();

            Console.Write("Enter An Employee Id: ");
            var empId = Convert.ToInt32(Console.ReadLine());

            //Report of Unallocated Seats to be shown here:
            unAllocatedReportManagerView.DisplaySeat();

            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.Allocate(entityId, empId);
        }

        public async Task DeAllocateSeatView()
        {
            IReportManager<SeatOverview> suaReportManager = new ReportManager<SeatOverview>("Report/seatallocatedList");
            IReportManagerView allocatedReportManagerView = new AllocatedReportManagerView(suaReportManager,null);

            //Report of allocated seats to be shown here:
            allocatedReportManagerView.DisplaySeat();

            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.DeAllocate(entityId);
        }

        public async Task OnBoardSeatsView(FacilityManagerView facilityManagerView, SeatManagerView seatManagerView) 
        {
            await facilityManagerView.AllFacilitiesView();

            Console.Write("Enter a Facility Where You Wish To Onboard Seats: ");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            seatManagerView.AddBulkSeatsView(facilityId);
        }

    }
}
