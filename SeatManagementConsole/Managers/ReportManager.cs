using SeatManagementAPI.Models;
using SeatManagementConsole;
using SeatManagementConsole.Interfaces;

internal class ReportManager<T> : IReportManager<T> where T:class
{
    private readonly APIService<T> _reportAPICall;
    public ReportManager(string apiEndPoint)
    {
        _reportAPICall = new APIService<T>(apiEndPoint);
    }
    public async Task<List<T>> GetAll()
    {
        return await _reportAPICall.GetAll<T>();
    }

}