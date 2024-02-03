using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedSubjectMarkListByCourseNameIdAndSubjectNameIdRequest : IRequest<List<SubjectMarkDto>>
    {
        public int CourseNameId { get; set; } 
        public int BnaSubjectNameId { get; set; }
    }
}

 