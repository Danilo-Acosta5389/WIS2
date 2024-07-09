using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WisApi.Models;
using WisApi.Models.DTO_s.ReportDTO;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository) 
        {
            _reportRepository = reportRepository;
        }

        [Authorize(Roles = "Admin, Super")]
        [HttpGet]
        public IActionResult GetAllReports()
        {
            var reports = _reportRepository.GetAll();
            return Ok(reports);
        }

        //The following two actions might be redundant
        [HttpGet("unhandled")]
        [Authorize(Roles = "Admin, Super")]
        public IActionResult GetUnHandledReports()
        {
            var reports = _reportRepository.GetByCondition(x => x.IsHandled == false);
            return Ok(reports);
        }

        [HttpGet("handled")]
        [Authorize(Roles = "Admin, Super")]
        public IActionResult GetHandledReports()
        {
            var reports = _reportRepository.GetByCondition(x => x.IsHandled == true);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = ("User, Creator, Admin, Super"))]
        public IActionResult CreateReport([FromBody] NewReportDTO report)
        {
            if (report == null) return BadRequest("Empty report filed");

            var user = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            var newReport = new ReportModel
            {
                Url = report.Url,
                User = user,
                Message = report.Message,
                Created = DateTime.UtcNow,
                Ip = ip
            };

            _reportRepository.Create(newReport);
            _reportRepository.Save();

            return Ok("Report successfully filed!");
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult UpdateReport()
        {

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult DeleteReport()
        {
            return Ok();
        }
    }
}
