using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorRoutineByTraineeIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}
