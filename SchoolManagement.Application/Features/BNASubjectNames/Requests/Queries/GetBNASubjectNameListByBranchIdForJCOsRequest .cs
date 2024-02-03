using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBNASubjectNameListByBranchIdForJCOsRequest : IRequest<List<BnaSubjectNameDto>>
    {  
        public int SaylorBranchId { get; set; } 
        public int CourseNameId { get; set; }
    } 
}
 
 