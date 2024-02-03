using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;
using SchoolManagement.Application.DTOs.TraineeNomination;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetStudentInfoByTraineeIdSpRequestHandler : IRequestHandler<GetStudentInfoByTraineeIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetStudentInfoByTraineeIdSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentInfoByTraineeIdSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetStudentInfoByTraineeId] {0}", request.TraineeId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           //StudentInfoByTraineeIdDto items = dataTable.AsEnumerable().Select(row =>
           // new StudentInfoByTraineeIdDto
           // {
           //     Pno = row.Field<string>("Pno"),
           //     Name = row.Field<string>("Name"),
           //     Position = row.Field<string>("Position"),
           //     DurationFrom = row.Field<DateTime>("DurationFrom"),
           //     DurationTo = row.Field<DateTime>("DurationTo"),
           //     CourseTitle = row.Field<string>("CourseTitle"),
           //     SchoolName = row.Field<string>("SchoolName"),
           //     BaseNames = row.Field<string>("BaseNames"),
           // });
            return dataTable;
         
        }
    }
}
