using MediatR;
using System.Collections.Generic;
using RonwellHR.Application.Employees.Models;

namespace RonwellHR.Application.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
