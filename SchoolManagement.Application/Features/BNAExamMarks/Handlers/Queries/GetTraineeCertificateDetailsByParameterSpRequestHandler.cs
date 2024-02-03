using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetTraineeCertificateDetailsByParameterSpRequestHandler : IRequestHandler<GetTraineeCertificateDetailsByParameterSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetTraineeCertificateDetailsByParameterSpRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetTraineeCertificateDetailsByParameterSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTraineeCertificateDetails] {0}, {1},{2}", request.BaseSchoolNameId,request.CourseDurationId, request.TraineeId);

            DataTable dataTable = _BnaExamMarkRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
