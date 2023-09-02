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

        [HttpGet("allocatedlist")]
        public IActionResult GetAllocated()
        {
           return Ok(_reportService.GetAllocatedList());
        }

        [HttpGet("deallocatedlist")] 
        public IActionResult GetDealloactedList()
        { 
            return Ok(_reportService.GetUnAllocatedList());
        }
    }
}
