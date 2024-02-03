using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetSelectedCourseInstructorIdByParametersRequest : IRequest<int>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }  
        public int BnaSubjectNameId { get; set; }
        public int TraineeId { get; set; } 
    }
}

 