using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetStudentInfoByTraineeIdSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}
