using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationByTypeAndNameFromSpRequest : IRequest<object>
    {        
        public int? CourseTypeId { get; set; }
        public int? CourseNameId { get; set; }
    }
}
