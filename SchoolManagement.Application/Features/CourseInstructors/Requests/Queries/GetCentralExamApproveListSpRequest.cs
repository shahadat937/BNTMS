using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetCentralExamApproveListSpRequest : IRequest<object>
    {
        public int CourseTypeId { get; set; }
        public int CourseNameId { get; set; }
    }
}
