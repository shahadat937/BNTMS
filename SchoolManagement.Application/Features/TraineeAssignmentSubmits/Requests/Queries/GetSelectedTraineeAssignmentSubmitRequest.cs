using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries
{
    public class GetSelectedTraineeAssignmentSubmitRequest : IRequest<List<SelectedModel>>
    {
    }
}
