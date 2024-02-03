using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetSelectedRoutineIdForStaffCollegeRequestHandler : IRequestHandler<GetSelectedRoutineIdForStaffCollegeRequest, int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;


        public GetSelectedRoutineIdForStaffCollegeRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;
        }

        public async Task<int> Handle(GetSelectedRoutineIdForStaffCollegeRequest request, CancellationToken cancellationToken)
        {
            var classRoutines = _classRoutineRepository.Where(x => x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.CourseDurationId == request.CourseDurationId).FirstOrDefault();

            //if (classRoutines != null)
            //{
                return classRoutines.ClassRoutineId;
            //}

            //else
            //{
                //throw new InvalidOperationException();
            //}
        }
    }
}
