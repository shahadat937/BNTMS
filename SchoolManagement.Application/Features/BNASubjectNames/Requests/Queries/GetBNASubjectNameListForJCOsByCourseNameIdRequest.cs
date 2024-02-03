using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBNASubjectNameListForJCOsByCourseNameIdRequest : IRequest<object>
    {          
        public int CourseDurationId { get; set; }
    } 
}
 
 