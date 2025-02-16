using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetSchoolExamApproveListSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string? SearchTerm { get; set; }
    }
}
