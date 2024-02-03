using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries   
{
    public class GetClassRoutineCountByParametersRequestHandler : IRequestHandler<GetClassRoutineCountByParametersRequest, int>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

            
        public GetClassRoutineCountByParametersRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<int> Handle(GetClassRoutineCountByParametersRequest request, CancellationToken cancellationToken)
        {
            var classRoutines =_classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId);
            int count = classRoutines.Count();
            return classRoutines.Count()+1;
        }
    }
}
