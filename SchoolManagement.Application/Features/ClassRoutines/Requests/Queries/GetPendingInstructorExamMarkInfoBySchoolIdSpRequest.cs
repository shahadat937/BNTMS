using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetPendingInstructorExamMarkInfoBySchoolIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
