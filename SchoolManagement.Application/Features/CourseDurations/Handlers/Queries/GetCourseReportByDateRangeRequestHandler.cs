using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseReportByDateRangeRequestHandler : IRequestHandler<GetCourseReportByDateRangeRequest, object>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _courseDuration;

        public GetCourseReportByDateRangeRequestHandler(ISchoolManagementRepository<CourseDuration> courseDuration)
        {
            _courseDuration = courseDuration;
        }
        public async Task<object> Handle(GetCourseReportByDateRangeRequest request, CancellationToken cancellationToken)
        {
            var sqQuery = string.Format(
        "Exec [spGetCourseReportInDateRange] '{0}', '{1}'",
        request.To.ToString("yyyy-MM-dd HH:mm:ss"),
        request.From.ToString("yyyy-MM-dd HH:mm:ss")
    );
            DataTable dataTable = _courseDuration.ExecWithSqlQuery(sqQuery);
            return dataTable;
        }
    }
}
