using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RonwellHR.Data.Repositories;

namespace RonwellHR.Application.Administration.Commands
{
    public class HireEmployeeCommandHandler : IRequestHandler<HireEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HireEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(HireEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new System.Exception("Employee not found.");
            }
            employee.IsHired = true;
            employee.HireDate = request.HireDate;
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return Unit.Value;
        }
    }
}
