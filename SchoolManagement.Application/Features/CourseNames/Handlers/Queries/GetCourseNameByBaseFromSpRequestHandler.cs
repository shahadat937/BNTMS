using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseNameByBaseFromSpRequestHandler : IRequestHandler<GetCourseNameByBaseFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetCourseNameByBaseFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCourseNameByBaseFromSpRequest request, CancellationToken cancellationToken)
        {

         
            var searchTerm = string.IsNullOrEmpty(request.SearchTerm) ? "NULL" : $"'{request.SearchTerm.Replace("'", "''")}'";
            var spQuery = String.Format("exec [spGetCourseListByBase] {0}, {1}", request.BaseNameId, searchTerm);

            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
