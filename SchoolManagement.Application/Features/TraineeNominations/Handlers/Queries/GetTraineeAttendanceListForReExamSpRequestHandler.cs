using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeAttendanceListForReExamSpRequestHandler : IRequestHandler<GetTraineeAttendanceListForReExamSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
         
        public GetTraineeAttendanceListForReExamSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeAttendanceListForReExamSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeAttendanceListForReExam] {0},{1},{2},{3},{4},{5},{6}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId,request.CourseSectionId,request.ClassRoutineId,request.AttendanceStatus);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
