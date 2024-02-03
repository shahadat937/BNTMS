using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetTodayClassScheduleByCourseInstructorIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}  
 