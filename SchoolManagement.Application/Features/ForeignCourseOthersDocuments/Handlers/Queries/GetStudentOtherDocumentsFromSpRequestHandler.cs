using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Queries
{
    public class GetStudentOtherDocumentsFromSpRequestHandler : IRequestHandler<GetStudentOtherDocumentsFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetStudentOtherDocumentsFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentOtherDocumentsFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetStudentOtherDocumentsByTraineeIdAndDurationId] {0},{1}", request.TraineeId, request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
