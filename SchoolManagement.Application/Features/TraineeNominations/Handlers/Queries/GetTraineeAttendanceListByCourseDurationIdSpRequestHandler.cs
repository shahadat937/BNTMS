using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeAttendanceListByCourseDurationIdSpRequestHandler : IRequestHandler<GetTraineeAttendanceListByCourseDurationIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
         
        public GetTraineeAttendanceListByCourseDurationIdSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeAttendanceListByCourseDurationIdSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeAttendanceListByCourseDurationId] {0},{1},{2},{3},{4},{5},{6}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId,request.CourseSectionId, request.ClassRoutineId,request.AttendanceStatus);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
