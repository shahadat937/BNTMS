using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetNominatedTraineeByTypeAndBaseSpRequestHandler : IRequestHandler<GetNominatedTraineeByTypeAndBaseSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetNominatedTraineeByTypeAndBaseSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNominatedTraineeByTypeAndBaseSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetCourseTraineeByTypeAndBaseForSchoolDb] {0},{1}", request.BaseNameId,request.OfficerTypeId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
