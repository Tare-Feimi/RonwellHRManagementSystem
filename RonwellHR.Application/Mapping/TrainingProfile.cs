using AutoMapper;
using RonwellHR.Domain.Entities;
using RonwellHR.Application.Trainings.Models;
using RonwellHR.Application.Trainings.Commands;

namespace RonwellHR.Application.Mapping
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<TrainingSession, TrainingSessionDto>();
            CreateMap<ScheduleTrainingSessionCommand, TrainingSession>();
        }
    }
}
