using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationListForNbcdFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int NbcdSchoolId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
 