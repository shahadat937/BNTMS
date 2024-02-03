using SchoolManagement.Application.DTOs.ReadingMaterial;
using MediatR;
using SchoolManagement.Application.DTOs.TraineeNomination;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands
{
    public class UpdateNominationCommand : IRequest<Unit>
    {
        public TraineeReligationDto TraineeReligationDto { get; set; }

    }
}
 