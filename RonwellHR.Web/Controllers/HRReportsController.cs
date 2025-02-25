using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using RonwellHR.Application.HRReports.Queries;

namespace RonwellHR.Web.Controllers
{
    public class HRReportsController : Controller
    {
        private readonly IMediator _mediator;
        public HRReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetHRReportQuery();
            var report = await _mediator.Send(query);
            return View(report);
        }
    }
}
