using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedMarkTypeByParametersFromSubjectMarkRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; } 
        public int CourseDurationId { get; set; } 
        public int BnaSubjectNameId { get; set; } 
        public int CourseModuleId { get; set; } 
    }
}

  