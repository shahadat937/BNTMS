using MediatR;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries
{  
    public class GetTraineeAssignmentListByParameterRequest : IRequest<List<TraineeAssignmentSubmitDto>>
    {
        public int TraineeId { get; set; }
        public int InstructorId { get; set; }
        public int BnaSubjectNameId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; } 
        public int CourseDurationId { get; set; }
        public int CourseInstructorId { get; set; } 
        public int InstructorAssignmentId { get; set; } 
    } 
}

 