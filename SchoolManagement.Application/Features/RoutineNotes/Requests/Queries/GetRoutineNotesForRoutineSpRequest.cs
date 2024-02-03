using MediatR;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Queries
{
    public class GetRoutineNotesForRoutineSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }        
        public int CourseWeekId { get; set; }        
    }
}
