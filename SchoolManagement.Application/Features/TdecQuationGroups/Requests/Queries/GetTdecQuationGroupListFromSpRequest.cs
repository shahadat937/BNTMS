using MediatR;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries
{
    public class GetTdecQuationGroupListFromSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
