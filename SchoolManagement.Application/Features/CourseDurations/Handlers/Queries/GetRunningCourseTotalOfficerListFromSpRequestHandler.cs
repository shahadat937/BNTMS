using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetRunningCourseTotalOfficerListFromSpRequestHandler : IRequestHandler<GetRunningCourseTotalOfficerListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetRunningCourseTotalOfficerListFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRunningCourseTotalOfficerListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetRunningCourseTotalOfficer] {0},'{1}'", request.TraineeStatusId, request.CurrentDate);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            var countv = dataTable.Rows.Count;
            return dataTable;
         
        }
    }
}
