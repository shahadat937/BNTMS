using MediatR;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetJcoSubjectListBySaylorBranchSpRequest : IRequest<object>
    {
        public int CourseNameId { get; set; }
        public int SaylorBranchId { get; set; } 
        public int SaylorSubBranchId { get; set; } 
    }
}
 