using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseTotalOfficerListBySchoolFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeStatusId { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
