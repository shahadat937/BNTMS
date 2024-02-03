using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetQexamRoutineByBranchIdSpRequestHandler : IRequestHandler<GetQexamRoutineByBranchIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _routineRepository;

        private readonly IMapper _mapper;

        public GetQexamRoutineByBranchIdSpRequestHandler(ISchoolManagementRepository<ClassRoutine> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetQexamRoutineByBranchIdSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetQexamRoutineByBranch] {0}, {1}", request.CourseDurationId, request.BranchId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
