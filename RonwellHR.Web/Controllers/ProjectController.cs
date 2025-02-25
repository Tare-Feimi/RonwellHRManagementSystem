using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using RonwellHR.Application.Projects.Commands;
using RonwellHR.Application.Projects.Queries;

namespace RonwellHR.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int employeeId = 0)
        {
            if (employeeId > 0)
            {
                var query = new RonwellHR.Application.Projects.Queries.GetProjectsByEmployeeQuery { EmployeeId = employeeId };
                var projects = await _mediator.Send(query);
                return View(projects);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectCommand command)
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
