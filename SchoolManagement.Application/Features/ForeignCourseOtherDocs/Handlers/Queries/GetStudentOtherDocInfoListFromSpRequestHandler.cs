using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Queries
{
    public class GetStudentOtherDocInfoListFromSpRequestHandler : IRequestHandler<GetStudentOtherDocInfoListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetStudentOtherDocInfoListFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentOtherDocInfoListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetStudentOtherDocInfoByDurationId] {0}", request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
