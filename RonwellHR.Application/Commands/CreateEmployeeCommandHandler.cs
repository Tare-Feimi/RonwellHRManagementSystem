using MediatR;
using RonwellHR.Domain.Entities;
using RonwellHR.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RonwellHR.Application.Employees.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Qualification = request.Qualification,
                Skills = request.Skills,
                Experience = request.Experience,
                LoginId = request.LoginId,
                Password = request.Password
            };

            await _employeeRepository.AddEmployeeAsync(employee);
            return employee.EmployeeId;
        }
    }
}
