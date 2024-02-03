using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetDataForPrintWeeklyRoutineFromSpRequestHandler : IRequestHandler<GetDataForPrintWeeklyRoutineFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetDataForPrintWeeklyRoutineFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetDataForPrintWeeklyRoutineFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetDataToPrintWeeklyRoutine] {0}", request.CourseWeekId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
