using AutoMapper;
using RonwellHR.Domain.Entities;
using RonwellHR.Application.Employees.Models;
using RonwellHR.Application.Employees.Commands;

namespace RonwellHR.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateEmployeeCommand, Employee>();
        }
    }
}
