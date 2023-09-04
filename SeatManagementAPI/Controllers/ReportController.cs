using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatManagementAPI.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("seatAllocatedlist")]
        public IActionResult GetSeatAllocated()
        {
           return Ok(_reportService.GetSeatAllocatedList());
        }

        [HttpGet("seatDeallocatedlist")] 
        public IActionResult GetSeatDealloactedList()
        { 
            return Ok(_reportService.GetSeatUnAllocatedList());
        }

        [HttpGet("cabinAllocatedlist")]
        public IActionResult GetCabinAllocated()
        {
            return Ok(_reportService.GetCabinAllocatedList());
        }

        [HttpGet("cabinDeallocatedlist")]
        public IActionResult GetCabinDealloactedList()
        {
            return Ok(_reportService.GetCabinUnAllocatedList());
        }
    }
}
