using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RonwellHR.Data.Repositories;
using RonwellHR.Application.Projects.Models;
using AutoMapper;

namespace RonwellHR.Application.Projects.Queries
{
    public class GetProjectsByEmployeeQueryHandler : IRequestHandler<GetProjectsByEmployeeQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectsByEmployeeQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetProjectsByEmployeeIdAsync(request.EmployeeId);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
    }
}
