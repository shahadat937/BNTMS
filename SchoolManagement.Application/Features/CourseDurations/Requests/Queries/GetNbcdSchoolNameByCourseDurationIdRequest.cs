using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNbcdSchoolNameByCourseDurationIdRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
  