using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetUpcommingClassesForInstructorDashboardSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; } 
        public int TraineeId { get; set; }
    }
}  
 