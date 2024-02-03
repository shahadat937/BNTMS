using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBNASubjectNameListByBranchIdRequest : IRequest<List<BnaSubjectNameDto>>
    {  
        public int BranchId { get; set; } 
        public int CourseNameId { get; set; }
    } 
}
 
 