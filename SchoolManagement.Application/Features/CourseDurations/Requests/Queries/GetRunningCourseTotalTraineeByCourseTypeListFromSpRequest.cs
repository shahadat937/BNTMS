using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseTotalTraineeByCourseTypeListFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int CourseTypeId { get; set; }
        public int TraineeStatusId { get; set; }

    }
}
