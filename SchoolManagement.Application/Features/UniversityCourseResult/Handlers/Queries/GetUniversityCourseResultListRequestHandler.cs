using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetUniversityCourseResultListRequestHandler : IRequestHandler<GetUniversityCourseResultListRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetUniversityCourseResultListRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetUniversityCourseResultListRequest request, CancellationToken cancellationToken)
        {

            //var sqlQuery = String.Format("select * from [UniversityCourseResult]");

             var spQuery = String.Format("exec [spGetUniversityCourseResultListBySchoolIdAndDurationId] {0},'{1}'", request.BaseSchoolNameId, request.CourseDurationId);

            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
           // dataTable.        
            return dataTable;
         
        }
    }
}
