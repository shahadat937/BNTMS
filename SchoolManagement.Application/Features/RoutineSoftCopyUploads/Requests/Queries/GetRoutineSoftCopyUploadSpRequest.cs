using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRoutineSoftCopyUploadSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}
 