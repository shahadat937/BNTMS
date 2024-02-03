using MediatR;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetExamStatusBySubjectListSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; } 
    }
}
 