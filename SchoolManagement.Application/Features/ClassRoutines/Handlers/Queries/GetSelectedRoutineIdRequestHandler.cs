using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetSelectedRoutineIdRequestHandler : IRequestHandler<GetSelectedRoutineIdRequest, int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedRoutineIdRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<int> Handle(GetSelectedRoutineIdRequest request, CancellationToken cancellationToken)
        {
            var classRoutines = _classRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.ClassPeriodId == request.ClassPeriodId).FirstOrDefault();
            return classRoutines.ClassRoutineId;
        }
    }
}
