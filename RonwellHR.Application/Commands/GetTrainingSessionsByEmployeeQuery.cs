using MediatR;
using System.Collections.Generic;
using RonwellHR.Application.Trainings.Models;

namespace RonwellHR.Application.Trainings.Queries
{
    public class GetTrainingSessionsByEmployeeQuery : IRequest<IEnumerable<TrainingSessionDto>>
    {
        public int EmployeeId { get; set; }
    }
}
