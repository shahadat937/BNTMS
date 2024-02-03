using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetBNASubjectNameListForJCOsByCourseNameIdRequestHandler : IRequestHandler<GetBNASubjectNameListForJCOsByCourseNameIdRequest, object>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        private readonly IMapper _mapper;
        public GetBNASubjectNameListForJCOsByCourseNameIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBNASubjectNameListForJCOsByCourseNameIdRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetJcosSubjectRoutine] {0}", request.CourseDurationId);

            DataTable dataTable = _BnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }

    }
}
