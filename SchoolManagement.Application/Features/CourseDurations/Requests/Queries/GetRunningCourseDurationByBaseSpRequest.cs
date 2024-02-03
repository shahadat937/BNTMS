using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseDurationByBaseSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int ViewStatus { get; set; }
    }
}
