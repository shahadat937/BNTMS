using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetExamMarkListForValidationSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
        public int BnasubjectNameId { get; set; }
        public int MarkTypeId { get; set; }
    }
}
  