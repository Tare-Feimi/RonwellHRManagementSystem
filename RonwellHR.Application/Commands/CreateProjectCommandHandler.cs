using MediatR;
using RonwellHR.Domain.Entities;
using RonwellHR.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RonwellHR.Application.Projects.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                EmployeeId = request.EmployeeId
            };

            await _projectRepository.AddProjectAsync(project);
            return project.ProjectId;
        }
    }
}
