using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
 
namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetModuleForRoutineRequest : IRequest<int?> 
    {
        public int BaseSchoolNameId { get; set; } 
        public int CourseNameId { get; set; } 
        public int BnaSubjectNameId { get; set; } 
    }
} 
 