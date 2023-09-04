
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;


namespace AssetManagementAPI.ControllerServices
{
    public class ReportService : IReportService
    {
        private readonly IRepository<SeatOverview> _seatAllocatedcontext;
        private readonly IRepository<SeatUnAllocatedView> _seatUnAllocatedcontext;
        private readonly IRepository<CabinOverview> _cabinAllocatedcontext;
        private readonly IRepository<CabinUnAllocatedView> _cabinUnAllocatedcontext;

        public ReportService(IRepository<SeatOverview> _seatAllocatedcontext, IRepository<SeatUnAllocatedView> _seatUnAllocatedcontext, 
            IRepository<CabinOverview> _cabinAllocatedcontext, IRepository<CabinUnAllocatedView> _cabinUnAllocatedcontext )
        {
            this._seatAllocatedcontext = _seatAllocatedcontext;
            this._seatUnAllocatedcontext = _seatUnAllocatedcontext;
            this._cabinAllocatedcontext = _cabinAllocatedcontext;
            this._cabinUnAllocatedcontext = _cabinUnAllocatedcontext;
        }

        public SeatOverview[] GetSeatAllocatedList()
        {
            return _seatAllocatedcontext.GetAll(); 
        }

        public SeatUnAllocatedView[] GetSeatUnAllocatedList()
        {
            return _seatUnAllocatedcontext.GetAll();
        }

        public CabinOverview[] GetCabinAllocatedList()
        {
            return _cabinAllocatedcontext.GetAll();
        }

        public CabinUnAllocatedView[] GetCabinUnAllocatedList()
        {
            return _cabinUnAllocatedcontext.GetAll();
        }
    }
}
