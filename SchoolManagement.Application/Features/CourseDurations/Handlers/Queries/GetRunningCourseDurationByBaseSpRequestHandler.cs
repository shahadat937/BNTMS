using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetRunningCourseDurationByBaseSpRequestHandler : IRequestHandler<GetRunningCourseDurationByBaseSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetRunningCourseDurationByBaseSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRunningCourseDurationByBaseSpRequest request, CancellationToken cancellationToken)
        {

            // Normalize the search term if provided
            string normalizedSearchTerm = string.IsNullOrWhiteSpace(request.SearchTerm)
                ? "NULL"
                : $"'{request.SearchTerm.Trim()}'";

            // Format the query with the new parameter
            var spQuery = string.Format(
                "exec [spGetRunningCourseDurationByBase] {0}, '{1}', {2}, {3}",
                request.BaseNameId,
                request.CurrentDate,
                request.ViewStatus,
                normalizedSearchTerm
            );

            // Execute the query and return the DataTable
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;

        }
    }
}
