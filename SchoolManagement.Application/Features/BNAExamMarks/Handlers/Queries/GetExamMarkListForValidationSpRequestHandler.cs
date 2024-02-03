using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using System.Data;
using SchoolManagement.Application.DTOs.BnaExamMark;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetExamMarkListForValidationSpRequestHandler : IRequestHandler<GetExamMarkListForValidationSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetExamMarkListForValidationSpRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetExamMarkListForValidationSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetExamMarkForValidation] {0},{1},{2},{3},{4}",request.BaseSchoolNameId,request.CourseDurationId,request.CourseSectionId,request.BnasubjectNameId,request.MarkTypeId);

            DataTable dataTable = _BnaExamMarkRepository.ExecWithSqlQuery(spQuery);

            BnaExamMark bnaExamMark = new BnaExamMark();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                bnaExamMark.TotalMark = dataTable.Rows[i]["Mark"].ToString();
            }

            return bnaExamMark.TotalMark;
        }
    }
}
