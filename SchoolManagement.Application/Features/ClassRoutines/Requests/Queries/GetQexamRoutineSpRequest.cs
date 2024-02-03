using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetQexamRoutineSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
} 
