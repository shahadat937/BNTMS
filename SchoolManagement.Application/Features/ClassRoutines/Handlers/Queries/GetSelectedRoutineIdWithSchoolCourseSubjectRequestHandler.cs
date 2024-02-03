using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetSelectedRoutineIdWithSchoolCourseSubjectRequestHandler : IRequestHandler<GetSelectedRoutineIdWithSchoolCourseSubjectRequest, int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedRoutineIdWithSchoolCourseSubjectRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<int> Handle(GetSelectedRoutineIdWithSchoolCourseSubjectRequest request, CancellationToken cancellationToken)
        {
            var classRoutines = _classRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.ClassTypeId == 4).FirstOrDefault();
            return classRoutines.ClassRoutineId;
        }
    }
}
