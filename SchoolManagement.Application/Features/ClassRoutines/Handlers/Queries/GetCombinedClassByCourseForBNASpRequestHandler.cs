using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetCombinedClassByCourseForBNASpRequestHandler : IRequestHandler<GetCombinedClassByCourseForBNASpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetCombinedClassByCourseForBNASpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCombinedClassByCourseForBNASpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetClassRoutineForCombinedBna] {0}, {1}, '{2}'", request.BaseSchoolNameId, request.CourseNameId, request.CurrentDate);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
