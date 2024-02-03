using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetSelectedSubjectNameListForInstructorFromSpRequest : IRequest<object>
    {            
        public int TraineeId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
} 
