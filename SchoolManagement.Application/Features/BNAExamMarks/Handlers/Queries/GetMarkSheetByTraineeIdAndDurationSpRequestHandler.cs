using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetMarkSheetByTraineeIdAndDurationSpRequestHandler : IRequestHandler<GetMarkSheetByTraineeIdAndDurationSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetMarkSheetByTraineeIdAndDurationSpRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetMarkSheetByTraineeIdAndDurationSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTraineeMarkListByTraineeId] {0},{1}", request.TraineeId, request.CourseDurationId);

            DataTable dataTable = _BnaExamMarkRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
