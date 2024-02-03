using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetAttendanceByTraineeIdAndCourseDurationSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
