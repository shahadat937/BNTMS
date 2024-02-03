using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSelectedSubjectNameForAssignmentSpRequestHandler : IRequestHandler<GetSelectedSubjectNameForAssignmentSpRequest, object>
    {

        private readonly ISchoolManagementRepository<MarkType> _MarkTypeRepository;

        private readonly IMapper _mapper;

        public GetSelectedSubjectNameForAssignmentSpRequestHandler(ISchoolManagementRepository<MarkType> MarkTypeRepository, IMapper mapper)
        {
            _MarkTypeRepository = MarkTypeRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetSelectedSubjectNameForAssignmentSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetSelectedSubjectNameForAssignment] {0},{1}", request.BaseSchoolNameId, request.CourseNameId);

            DataTable dataTable = _MarkTypeRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
