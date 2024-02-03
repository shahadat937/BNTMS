using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetJcoSubjectListBySaylorBranchSpRequestHandler : IRequestHandler<GetJcoSubjectListBySaylorBranchSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetJcoSubjectListBySaylorBranchSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetJcoSubjectListBySaylorBranchSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetJcoSubjectBySaylorBranch] {0},{1},{2}", request.CourseNameId, request.SaylorBranchId, request.SaylorSubBranchId);

            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
