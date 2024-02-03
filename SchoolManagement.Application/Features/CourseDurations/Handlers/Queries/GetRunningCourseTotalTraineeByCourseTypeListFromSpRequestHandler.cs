using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetRunningCourseTotalTraineeByCourseTypeListFromSpRequestHandler : IRequestHandler<GetRunningCourseTotalTraineeByCourseTypeListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetRunningCourseTotalTraineeByCourseTypeListFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRunningCourseTotalTraineeByCourseTypeListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetRunningCourseTotalTraineeByCourseType] '{0}',{1}, {2}", request.CurrentDate, request.CourseTypeId, request.TraineeStatusId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            var countv = dataTable.Rows.Count;
            return dataTable;
         
        }
    }
}
