using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetCurrentRoutineForStudentDashboardSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; } 
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
    }
} 
