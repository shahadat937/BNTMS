using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetJcoRoutineForStudentDashboardSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; } 
        public int CourseDurationId { get; set; }
        public int SaylorBranchId { get; set; }
        public int SaylorSubBranchId { get; set; }
    }
} 
