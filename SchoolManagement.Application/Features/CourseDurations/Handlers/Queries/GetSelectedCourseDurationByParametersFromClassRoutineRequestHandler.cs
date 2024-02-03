using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries   
{
    public class GetSelectedCourseDurationByParametersFromClassRoutineRequestHandler : IRequestHandler<GetSelectedCourseDurationByParametersFromClassRoutineRequest,int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedCourseDurationByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<int> Handle(GetSelectedCourseDurationByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            var classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.ClassPeriodId == request.ClassPeriodId, "CourseDuration").FirstOrDefault();
           
            var courseDurationId = classRoutines.CourseDurationId;
           
            return courseDurationId.Value;
        }
    }
}
