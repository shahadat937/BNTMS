using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Queries
{
    public class GetStudentOtherDocInfoFromSpRequestHandler : IRequestHandler<GetStudentOtherDocInfoFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetStudentOtherDocInfoFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentOtherDocInfoFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetStudentOtherDocInfoByTraineeIdAndDurationId] {0},{1}", request.TraineeId, request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
