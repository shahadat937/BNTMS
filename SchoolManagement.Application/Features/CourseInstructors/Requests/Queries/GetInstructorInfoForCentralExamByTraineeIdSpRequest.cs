using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorInfoForCentralExamByTraineeIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseTypeId { get; set; }
        public int CourseNameId { get; set; }
    }
}
