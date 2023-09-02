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
            Console.WriteLine("How many number of seats does the facility have?");
            var totalSeats = Convert.ToInt32(Console.ReadLine());
            string extension = "/addbatch";
            seatManager.AddMany(facilityId, totalSeats, extension);
        }

        public async void AllocateSeatView()
        {
            Console.WriteLine("Enter An Employee Id:");
            var empId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter An Seat Id:");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");


            SeatAllocater.Allocate(entityId, empId);
        }

        public async void DeAllocateSeatView()
        {
            Console.WriteLine("Enter An Seat Id:");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.DeAllocate(entityId);
        }
    }
}
