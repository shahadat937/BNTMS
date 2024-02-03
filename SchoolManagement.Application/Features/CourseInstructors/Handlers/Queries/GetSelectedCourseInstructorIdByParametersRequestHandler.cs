using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries   
{ 
    public class GetSelectedCourseInstructorIdByParametersRequestHandler : IRequestHandler<GetSelectedCourseInstructorIdByParametersRequest, int>
    {
        private readonly ISchoolManagementRepository<CourseInstructor> _CourseInstructorRepository;

           
        public GetSelectedCourseInstructorIdByParametersRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository)
        {
            _CourseInstructorRepository = CourseInstructorRepository;    
        }

        public async Task<int> Handle(GetSelectedCourseInstructorIdByParametersRequest request, CancellationToken cancellationToken)
        {
            var CourseInstructors = _CourseInstructorRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.TraineeId==request.TraineeId).FirstOrDefault();
           
            var courseInstructorId = CourseInstructors.CourseInstructorId;
           
            return courseInstructorId;
        }
    }
}
