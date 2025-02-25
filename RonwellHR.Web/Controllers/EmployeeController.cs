using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using RonwellHR.Application.Employees.Commands;
using RonwellHR.Application.Employees.Queries;

namespace RonwellHR.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllEmployeesQuery();
            var employees = await _mediator.Send(query);
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
    }
}
