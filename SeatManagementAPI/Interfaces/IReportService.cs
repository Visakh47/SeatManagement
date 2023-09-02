using SeatManagementAPI.Models;

namespace SeatManagementAPI.Interfaces
{
    public interface IReportService
    {
        Overview[] GetAllocatedList();
        UnAllocatedView[] GetUnAllocatedList();
    }
}
