using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;

public class UnAllocatedReportManagerView<T> : IReportManagerView<T> 
{
    private readonly IReportManager<UnAllocatedView> uaReportManager;

    public UnAllocatedReportManagerView(IReportManager<UnAllocatedView> uaReportManager)
    {
        this.uaReportManager = uaReportManager;
    }
    public async void Display() {
        var unAllocatedReports = uaReportManager.GetAll().Result;

        Console.WriteLine("List of Unallocated Seats:");

        foreach(var report in unAllocatedReports)
        {
            Console.WriteLine($"{report.CityAbbreviation} - {report.BuildingAbbreviation} - {report.FacilityFloor} - {report.FacilityName} - {report.SeatCode}");
        }
    }
}