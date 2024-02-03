using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeListForAssignmentSpRequestHandler : IRequestHandler<GetTraineeListForAssignmentSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
          
        public GetTraineeListForAssignmentSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeListForAssignmentSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeListForAssignmentMarkByCourseDurationId] {0},{1},{2}", request.CourseDurationId, request.CourseNameId, request.CourseSectionId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
