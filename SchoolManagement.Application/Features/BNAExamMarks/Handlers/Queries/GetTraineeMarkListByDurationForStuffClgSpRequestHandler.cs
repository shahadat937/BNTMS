using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetTraineeMarkListByDurationForStuffClgSpRequestHandler : IRequestHandler<GetTraineeMarkListByDurationForStuffClgSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetTraineeMarkListByDurationForStuffClgSpRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetTraineeMarkListByDurationForStuffClgSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTraineeMarkListForStuffClg] {0}", request.CourseDurationId);

            DataTable dataTable = _BnaExamMarkRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
