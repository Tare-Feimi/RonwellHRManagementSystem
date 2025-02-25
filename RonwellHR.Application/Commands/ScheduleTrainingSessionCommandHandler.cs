using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RonwellHR.Domain.Entities;
using RonwellHR.Data.Repositories;

namespace RonwellHR.Application.Trainings.Commands
{
    public class ScheduleTrainingSessionCommandHandler : IRequestHandler<ScheduleTrainingSessionCommand, int>
    {
        private readonly ITrainingRepository _trainingRepository;

        public ScheduleTrainingSessionCommandHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<int> Handle(ScheduleTrainingSessionCommand request, CancellationToken cancellationToken)
        {
            var session = new TrainingSession
            {
                Topic = request.Topic,
                Date = request.Date,
                EmployeeId = request.EmployeeId
            };

            await _trainingRepository.AddTrainingSessionAsync(session);
            return session.TrainingSessionId;
        }
    }
}
