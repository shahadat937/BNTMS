using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetNominatedForeignTraineeBySchoolFromSpRequestHandler : IRequestHandler<GetNominatedForeignTraineeBySchoolFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetNominatedForeignTraineeBySchoolFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNominatedForeignTraineeBySchoolFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetRunningCourseTotalForeignTraineeForSchoolDb] '{0}', {1}, {2}", request.CurrentDate, request.BaseSchoolNameId, request.OfficerTypeId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
