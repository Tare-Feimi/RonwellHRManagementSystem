using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Threading.Tasks;
using RonwellHR.Application.Administration.Commands;

namespace RonwellHR.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IMediator _mediator;

        public AdministrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hire()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hire(int employeeId, DateTime hireDate)
        {
            var command = new HireEmployeeCommand { EmployeeId = employeeId, HireDate = hireDate };
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
