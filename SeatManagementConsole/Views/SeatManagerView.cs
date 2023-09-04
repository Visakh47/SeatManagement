using SeatManagementAPI.Models;
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

            Console.Write("How many number of seats does the facility have: ");
            var totalSeats = Convert.ToInt32(Console.ReadLine());

            string extension = $"/addbatch?FacilityId={facilityId}&totalSeats={totalSeats}";
            seatManager.AddMany(extension);
        }

        public async Task AllocateSeatView()
        {
            IReportManager<UnAllocatedView> uaReportManager = new ReportManager<UnAllocatedView>("Report/deallocatedList");
            IReportManagerView<UnAllocatedView> unAllocatedReportManagerView = new UnAllocatedReportManagerView<UnAllocatedView>(uaReportManager);
            IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
            EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);

            //List of unallocated employees to be shown here:
            await employeeManagerView.ListUnAllocatedEmployeesView();

            Console.Write("Enter An Employee Id: ");
            var empId = Convert.ToInt32(Console.ReadLine());

            //Report of Unallocated Seats to be shown here:
            unAllocatedReportManagerView.Display();

            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.Allocate(entityId, empId);
        }

        public async Task DeAllocateSeatView()
        {
            IReportManager<Overview> aReportManager = new ReportManager<Overview>("Report/allocatedList");
            IReportManagerView<Overview> allocatedReportManagerView = new AllocatedReportManagerView<Overview>(aReportManager);

            //Report of allocated seats to be shown here:
            allocatedReportManagerView.Display();

            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.DeAllocate(entityId);
        }
    }
}
