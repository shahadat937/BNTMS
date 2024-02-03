using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries
{
    public class GetInstructorByParametersRequest : IRequest<List<BnaExamInstructorAssignDto>>
    {
        public int BaseSchoolNameId { get; set; }  
        public int CourseNameId { get; set; }
        public int CourseModuleId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}

 