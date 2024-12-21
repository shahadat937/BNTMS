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
    public class GetCourseTarminitedByThursDayRequestHandler : IRequestHandler<GetCourseTarminitedByThursDayRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseTarminitedByThursDayRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository)
        {
            _courseDurationRepository = courseDurationRepository;
        }
        public async Task<object> Handle(GetCourseTarminitedByThursDayRequest request, CancellationToken cancellationToken)
        {
            string formattedDate = request.NextThursDayDate.ToString("yyyy-MM-dd");
            string spQuery = string.Format("exec [spCourseTraminitedOnThursedDay] '{0}'", formattedDate);

            DataTable datatable = _courseDurationRepository.ExecWithSqlQuery(spQuery);

            return datatable;
        }
    }
}
