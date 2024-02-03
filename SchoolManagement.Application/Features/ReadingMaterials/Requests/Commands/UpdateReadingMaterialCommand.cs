using SchoolManagement.Application.DTOs.ReadingMaterial;
using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands
{
    public class UpdateReadingMaterialCommand : IRequest<Unit>
    {
        public CreateReadingMaterialDto CreateReadingMaterialDto { get; set; }

    }
}
