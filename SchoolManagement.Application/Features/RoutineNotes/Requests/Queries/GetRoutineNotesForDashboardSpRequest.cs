using MediatR;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Queries
{
    public class GetRoutineNotesForDashboardSpRequest : IRequest<object>
    {
        public DateTime Current { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }        
    }
}
