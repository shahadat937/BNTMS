using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseNameByBaseFromSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
    }
}
