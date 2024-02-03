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
    public class GetCourseDurationByBaseSchoolNameAndCourseNameRequestHandler : IRequestHandler<GetCourseDurationByBaseSchoolNameAndCourseNameRequest, int>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

            
        public GetCourseDurationByBaseSchoolNameAndCourseNameRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository)
        {
            _courseDurationRepository = courseDurationRepository;    
        }

        public async Task<int> Handle(GetCourseDurationByBaseSchoolNameAndCourseNameRequest request, CancellationToken cancellationToken)
        {
            var courseDurations = _courseDurationRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId).FirstOrDefault();
           
            var courseDurationId = courseDurations.CourseDurationId;
           
            return courseDurationId;
        }
    }
}
