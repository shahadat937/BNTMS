using MediatR;
using SchoolManagement.Application.DTOs.InstructorAssignments;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetInstructorAssignmentListByInstructorIdRequest : IRequest<List<InstructorAssignmentDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; }
        public int InstructorId { get; set; }     
        
    } 
}

 