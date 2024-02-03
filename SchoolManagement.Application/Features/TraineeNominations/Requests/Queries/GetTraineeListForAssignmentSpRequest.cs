using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeListForAssignmentSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseSectionId { get; set; }
    }
}
   