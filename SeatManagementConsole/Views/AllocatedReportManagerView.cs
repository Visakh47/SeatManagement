using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;

public class AllocatedReportManagerView<T> : IReportManagerView<T> 
{
    private readonly IReportManager<Overview> reportManager;

    public AllocatedReportManagerView(IReportManager<Overview> reportManager)
    {
        this.reportManager = reportManager;
    }
    public async void Display() {
        var allocatedReports = reportManager.GetAll().Result;

        Console.WriteLine("List of Allocated Seats:");
        Console.WriteLine("Seat Id. City Abbreviation - Building Abbreviation - FacilityFloor - FacilityName - SeatCode -> EmployeeName\n");
        foreach (var report in allocatedReports)
        {
            Console.WriteLine($"{report.SeatId}. {report.CityAbbreviation} - {report.BuildingAbbreviation} - {report.FacilityFloor} - {report.FacilityName} - {report.SeatCode} -> {report.EmployeeName}");
        }
    }

    public Task GenerateReport()
    {
        throw new NotImplementedException();
    }
}