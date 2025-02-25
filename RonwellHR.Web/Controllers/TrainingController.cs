using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using RonwellHR.Application.Trainings.Commands;
using RonwellHR.Application.Trainings.Queries;

namespace RonwellHR.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly IMediator _mediator;
        public TrainingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int employeeId = 0)
        {
            if (employeeId > 0)
            {
                var query = new RonwellHR.Application.Trainings.Queries.GetTrainingSessionsByEmployeeQuery { EmployeeId = employeeId };
                var sessions = await _mediator.Send(query);
                return View(sessions);
            }
            return View(); 
        }

        public IActionResult Schedule()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Schedule(ScheduleTrainingSessionCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction("Index");
            }
            return View(command);
        }
    }
}
