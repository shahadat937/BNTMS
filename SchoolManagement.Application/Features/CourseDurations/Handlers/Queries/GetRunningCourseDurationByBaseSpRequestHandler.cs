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
            
            var spQuery = String.Format("exec [spGetRunningCourseDurationByBase] {0},'{1}',{2}", request.BaseNameId, request.CurrentDate, request.ViewStatus);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
