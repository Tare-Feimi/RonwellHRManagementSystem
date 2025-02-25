using MediatR;
using System.Collections.Generic;
using RonwellHR.Application.Projects.Models;

namespace RonwellHR.Application.Projects.Queries
{
    public class GetProjectsByEmployeeQuery : IRequest<IEnumerable<ProjectDto>>
    {
        public int EmployeeId { get; set; }
    }
}
