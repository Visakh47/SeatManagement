
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;


namespace AssetManagementAPI.ControllerServices
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Overview> _Allocatedcontext;
        private readonly IRepository<UnAllocatedView> _unAllocatedcontext;

        public ReportService(IRepository<Overview> Allocatedcontext, IRepository<UnAllocatedView> UnAllocatedcontext)
        {
            _Allocatedcontext = Allocatedcontext;
            _unAllocatedcontext = UnAllocatedcontext;
        }

        public Overview[] GetAllocatedList()
        {
            return _Allocatedcontext.GetAll(); 
        }

        public UnAllocatedView[] GetUnAllocatedList()
        {
            return _unAllocatedcontext.GetAll();
        }
    }
}
