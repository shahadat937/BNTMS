using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetTraineeAttendanceListSpRequest : IRequest<object>
    {
        public int? TraineeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? AttendanceStatus { get; set; }
    }
}
