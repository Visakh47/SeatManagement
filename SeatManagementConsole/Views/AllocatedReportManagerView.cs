﻿using SeatManagementAPI.Models;
using SeatManagementConsole.Interfaces;

public class AllocatedReportManagerView : IReportManagerView
{
    private readonly IReportManager<SeatOverview> saReportManager;
    private readonly IReportManager<CabinOverview> caReportManager;

    public AllocatedReportManagerView(IReportManager<SeatOverview> saReportManager, IReportManager<CabinOverview> caReportManager)
    {
        this.saReportManager = saReportManager;
        this.caReportManager = caReportManager;
    }
    public async void DisplaySeat() {
        var allocatedReports = saReportManager.GetAll().Result;

        Console.WriteLine("List of Allocated Seats:");
        Console.WriteLine("Seat Id. City Abbreviation - Building Abbreviation - FacilityFloor - FacilityName - SeatCode -> EmployeeName\n");
        foreach (var report in allocatedReports)
        {
            Console.WriteLine($"{report.SeatId}. {report.CityAbbreviation} - {report.BuildingAbbreviation} - {report.FacilityFloor} - {report.FacilityName} - {report.SeatCode} -> {report.EmployeeName}");
        }
    }

    public async void DisplayCabin()
    {
        var allocatedCabinReports = caReportManager.GetAll().Result;

        Console.WriteLine("List of Allocated Cabins:");
        Console.WriteLine("Cabin Id. City Abbreviation - Building Abbreviation - FacilityFloor - FacilityName - CabinCode -> EmployeeName\n");
        foreach (var report in allocatedCabinReports)
        {
            Console.WriteLine($"{report.CabinId}. {report.CityAbbreviation} - {report.BuildingAbbreviation} - {report.FacilityFloor} - {report.FacilityName} - {report.CabinCode} -> {report.EmployeeName}");
        }
    }

    public Task GenerateReportView()
    {
        throw new NotImplementedException();
    }
}