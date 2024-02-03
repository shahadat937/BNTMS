using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetApproveMarkTypeByParametersForCentralExamRequest : IRequest<List<SelectedModel>>
    {
        public int CourseNameId { get; set; } 
        public int CourseDurationId { get; set; } 
        public int BnaSubjectNameId { get; set; } 
        public bool IsApproved { get; set; }
    }
}

  