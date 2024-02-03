using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedCourseListBySchoolFromSpRequest : IRequest<object>
    {        
        public DateTime? CurrentDate { get; set; }
        public int? BaseSchoolNameId { get; set; }
    }
}
