using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Queries
{
    public class GetTdecQuationGroupListFromSpRequestHandler : IRequestHandler<GetTdecQuationGroupListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TdecQuationGroup> _TdecQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetTdecQuationGroupListFromSpRequestHandler(ISchoolManagementRepository<TdecQuationGroup> TdecQuationGroupRepository, IMapper mapper)
        {
            _TdecQuationGroupRepository = TdecQuationGroupRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTdecQuationGroupListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTdecQuestionGroupList] {0},{1},{2}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId);
            
            DataTable dataTable = _TdecQuationGroupRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
