using MediatR;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedSubjectMarkForAssignmentsSpRequest : IRequest<object>
    {        
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
    } 
}
 