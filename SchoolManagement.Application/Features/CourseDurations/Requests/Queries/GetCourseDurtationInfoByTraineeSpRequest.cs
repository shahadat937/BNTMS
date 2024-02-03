using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurtationInfoByTraineeSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
    }
}
