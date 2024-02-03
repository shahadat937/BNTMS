using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using System.Data;
using SchoolManagement.Application.DTOs.BnaExamMark;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetTraineeMarkListByDurationForJcoSpRequestHandler : IRequestHandler<GetTraineeMarkListByDurationForJcoSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetTraineeMarkListByDurationForJcoSpRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetTraineeMarkListByDurationForJcoSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTraineeMarkListForJco] {0}", request.CourseDurationId);

            DataTable dataTable = _BnaExamMarkRepository.ExecWithSqlQuery(spQuery);

            List<JcoExamMarkListDto> jcoExamMarkList = new List<JcoExamMarkListDto>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                JcoExamMarkListDto jcoExamMark = new JcoExamMarkListDto();
                jcoExamMark.Ser = Convert.ToInt32(i+1);
                jcoExamMark.Ono = dataTable.Rows[i]["Pno"].ToString();
                jcoExamMark.SaylorBranch = dataTable.Rows[i]["SaylorBranch"].ToString();
                jcoExamMark.SaylorSubBranch = dataTable.Rows[i]["SaylorSubBranch"].ToString();
                //jcoExamMark.IndexNo = dataTable.Rows[i]["IndexNo"].ToString();
                //jcoExamMark.NoOfAttempt = dataTable.Rows[i]["NoOfAttempt"].ToString();
                //jcoExamMark.Billet = dataTable.Rows[i]["Billet"].ToString();
                //jcoExamMark.SubjectName = dataTable.Rows[i]["SubjectName"].ToString();
                //jcoExamMark.TotalObtained = dataTable.Rows[i]["Total Obtained"].ToString();
                //jcoExamMark.TotalMark = dataTable.Rows[i]["Total Mark"].ToString();
                //jcoExamMark.Percentage = dataTable.Rows[i]["Percentage"].ToString();
                //jcoExamMark.PassStatus = dataTable.Rows[i]["PassStatus"].ToString();

                jcoExamMarkList.Add(jcoExamMark);
            }

            return dataTable;
        }
    }
}
