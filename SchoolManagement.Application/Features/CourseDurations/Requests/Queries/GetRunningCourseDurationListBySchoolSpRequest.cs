using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseDurationListBySchoolSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
