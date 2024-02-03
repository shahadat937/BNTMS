using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
 
namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetSelectedRoutineIdFilterRequestHandler : IRequestHandler<GetSelectedRoutineIdFilterRequest, int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedRoutineIdFilterRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<int> Handle(GetSelectedRoutineIdFilterRequest request, CancellationToken cancellationToken)
        { 
            var classRoutines = _classRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.ClassPeriodId == request.ClassPeriodId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId && (!x.Date.HasValue || x.Date.Value.Date == request.Date)).FirstOrDefault();
            return classRoutines.ClassRoutineId;
        }
    }
}
