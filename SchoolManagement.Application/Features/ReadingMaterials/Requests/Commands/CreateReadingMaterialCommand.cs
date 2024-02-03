using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands
{
    public class CreateReadingMaterialCommand : IRequest<BaseCommandResponse>
    {
        public CreateReadingMaterialDto ReadingMaterialDto { get; set; }

    }
}
