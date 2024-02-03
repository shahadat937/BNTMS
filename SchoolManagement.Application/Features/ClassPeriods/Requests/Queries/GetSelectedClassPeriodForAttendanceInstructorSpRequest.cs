using MediatR;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetSelectedClassPeriodForAttendanceInstructorSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; }
        public int TraineeId { get; set; }
    }
} 
  