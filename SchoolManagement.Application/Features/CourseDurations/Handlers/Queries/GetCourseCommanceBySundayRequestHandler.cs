using AutoMapper;
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
    public class GetCourseCommanceBySundayRequestHandler : IRequestHandler<GetCourseCommanceBySundayRequest, object>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseCommanceBySundayRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository)
        {
            _courseDurationRepository = courseDurationRepository;
        }
        public async Task<object> Handle(GetCourseCommanceBySundayRequest request, CancellationToken cancellationToken)
        {
            string formattedDate = request.NextSundayDate.ToString("yyyy-MM-dd");
            string spQuery = string.Format("exec [spCourseCommanceBySunday] '{0}'", formattedDate);

            DataTable datatable = _courseDurationRepository.ExecWithSqlQuery(spQuery);

            return datatable;
        }
    }
}
