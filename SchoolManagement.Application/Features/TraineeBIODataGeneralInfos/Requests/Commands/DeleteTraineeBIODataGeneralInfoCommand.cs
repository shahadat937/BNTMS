using MediatR;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands
{
    public class DeleteTraineeBioDataGeneralInfoCommand : IRequest
    {
        public int TraineeId { get; set; }
    }
}
