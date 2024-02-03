using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetTraineeAttendanceDetailsByTraineeIdSpRequest : IRequest<object>
    {
        public int? TraineeId { get; set; }
    }
}
