using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseNameBySchoolFromSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
