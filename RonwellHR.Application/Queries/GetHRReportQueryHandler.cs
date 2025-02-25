using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RonwellHR.Data.Repositories;
using RonwellHR.Application.HRReports.Models;
using System.Linq;

namespace RonwellHR.Application.HRReports.Queries
{
    public class GetHRReportQueryHandler : IRequestHandler<GetHRReportQuery, HRReportDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITrainingRepository _trainingRepository;

        public GetHRReportQueryHandler(
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository,
            ITrainingRepository trainingRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<HRReportDto> Handle(GetHRReportQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            var projects = await _projectRepository.GetAllProjectsAsync();
            var trainingSessions = await _trainingRepository.GetAllTrainingSessionsAsync();

            var report = new HRReportDto
            {
                TotalEmployees = employees.Count(),
                TotalProjects = projects.Count(),
                TotalTrainingSessions = trainingSessions.Count()
            };

            return report;
        }
    }
}
