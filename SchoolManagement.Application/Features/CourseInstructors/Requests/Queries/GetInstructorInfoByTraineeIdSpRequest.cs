using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorInfoByTraineeIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}
