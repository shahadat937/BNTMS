using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetQexamRoutineByBranchIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int BranchId { get; set; }
    }
} 
