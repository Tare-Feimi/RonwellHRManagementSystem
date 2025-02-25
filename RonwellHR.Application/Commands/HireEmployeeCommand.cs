using MediatR;
using System;

namespace RonwellHR.Application.Administration.Commands
{
    public class HireEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
    }
}
