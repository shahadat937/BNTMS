using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSubjectInstructorListByCourseDurationFromSpRequestHandler : IRequestHandler<GetSubjectInstructorListByCourseDurationFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetSubjectInstructorListByCourseDurationFromSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetSubjectInstructorListByCourseDurationFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetInstructorListByCourseDuration] {0}", request.CourseDurationId);
            
            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            

            return dataTable;
         
        }
    }
}
