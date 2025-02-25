using MediatR;
using RonwellHR.Application.HRReports.Models;

namespace RonwellHR.Application.HRReports.Queries
{
    public class GetHRReportQuery : IRequest<HRReportDto>
    {
    }
}
