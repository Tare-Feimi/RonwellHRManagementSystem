using AutoMapper;
using RonwellHR.Domain.Entities;
using RonwellHR.Application.Projects.Models;
using RonwellHR.Application.Projects.Commands;

namespace RonwellHR.Application.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<CreateProjectCommand, Project>();
        }
    }
}
