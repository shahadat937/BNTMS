using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseDurationForCentralExamListSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int CourseNameId { get; set; }
    }
}
