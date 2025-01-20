using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetIsAllPassingOutCourseCompleteRequestHandler : IRequestHandler<GetIsAllPassingOutCourseCompleteRequest, bool>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseDuration> _courseDurationRepository;
        public GetIsAllPassingOutCourseCompleteRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseDuration> courseDurationRepository)
        {
            _courseDurationRepository = courseDurationRepository;
        }
        public async Task<bool> Handle(GetIsAllPassingOutCourseCompleteRequest request, CancellationToken cancellationToken)
        {
            DateTime today = DateTime.Today;
            var course = await _courseDurationRepository.FindOneAsync(x => x.CourseTypeId == request.CourseTypeId && x.DurationTo < today && x.IsCompletedStatus == 0);
            if(course != null)
            {
                return false;
            }
            return true;
        }
    }
}
