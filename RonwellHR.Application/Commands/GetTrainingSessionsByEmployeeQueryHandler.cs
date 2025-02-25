using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RonwellHR.Data.Repositories;
using RonwellHR.Application.Trainings.Models;
using AutoMapper;

namespace RonwellHR.Application.Trainings.Queries
{
    public class GetTrainingSessionsByEmployeeQueryHandler : IRequestHandler<GetTrainingSessionsByEmployeeQuery, IEnumerable<TrainingSessionDto>>
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public GetTrainingSessionsByEmployeeQueryHandler(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainingSessionDto>> Handle(GetTrainingSessionsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _trainingRepository.GetTrainingSessionsByEmployeeIdAsync(request.EmployeeId);
            return _mapper.Map<IEnumerable<TrainingSessionDto>>(sessions);
        }
    }
}
