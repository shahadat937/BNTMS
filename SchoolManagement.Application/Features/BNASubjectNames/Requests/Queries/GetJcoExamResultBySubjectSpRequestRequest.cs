using MediatR;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetJcoExamResultBySubjectSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; } 
        public int ResultStatus { get; set; } 
    }
}
 