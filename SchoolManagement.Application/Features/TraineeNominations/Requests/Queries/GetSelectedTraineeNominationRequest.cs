using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetSelectedTraineeNominationRequest : IRequest<List<SelectedModel>>
    {

    }
}
