using SeatManagementAPI.Models;

namespace SeatManagementAPI.Interfaces
{
    public interface IReportService
    {
        SeatOverview[] GetSeatAllocatedList();
        SeatUnAllocatedView[] GetSeatUnAllocatedList();

        CabinOverview[] GetCabinAllocatedList();
        CabinUnAllocatedView[] GetCabinUnAllocatedList();
    }
}
