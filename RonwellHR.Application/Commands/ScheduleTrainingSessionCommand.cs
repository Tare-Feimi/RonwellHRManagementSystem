using MediatR;
using System;

namespace RonwellHR.Application.Trainings.Commands
{
    public class ScheduleTrainingSessionCommand : IRequest<int>
    {
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }
}
