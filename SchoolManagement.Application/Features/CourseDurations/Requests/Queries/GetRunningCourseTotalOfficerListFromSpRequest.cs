using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseTotalOfficerListFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeStatusId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
