using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetBnaSubjectNameByParameterFromSpRequestHandler : IRequestHandler<GetBnaSubjectNameByParameterFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetBnaSubjectNameByParameterFromSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetBnaSubjectNameByParameterFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetClassRoutineTotalPeriod] {0},{1},{2}", request.BaseSchoolNameId,request.CourseNameId, request.BnaSubjectNameId);
            
            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            var totalPeriod = "";

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                totalPeriod = row["TotalPeriod"].ToString();
            }

            return totalPeriod;
         
        }
    }
}
