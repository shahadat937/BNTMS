using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedSubjectMarkBySubjectRequest : IRequest<List<SubjectMarkDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}

 