using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetExamRoutineForStudentDashboardSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
} 
