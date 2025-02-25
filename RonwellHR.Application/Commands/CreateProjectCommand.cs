using MediatR;
using System;

namespace RonwellHR.Application.Projects.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
