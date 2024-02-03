using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByParameterSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int TraineeId { get; set; }
    }
}
 