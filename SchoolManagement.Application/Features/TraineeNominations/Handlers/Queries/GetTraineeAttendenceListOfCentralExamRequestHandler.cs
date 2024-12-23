using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeAttendenceListOfCentralExamRequestHandler : IRequestHandler<GetTraineeAttendenceListOfCentralExamRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetTraineeAttendenceListOfCentralExamRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }
        public async Task<object> Handle(GetTraineeAttendenceListOfCentralExamRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeAttendanceListCentralExam] {0},{1},{2},{3},{4}",  request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId,  request.ClassRoutineId, request.AttendanceStatus);
            //var spQuery = String.Format("exec [spGetQExamAttendanceListByCourseDurationId] {0},{1},{2},{3},{4}", request.CourseNameId,  request.CourseDurationId, request.BnaSubjectNameId, request.ClassRoutineId, request.AttendanceStatus);


            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;
        }
    }
}
