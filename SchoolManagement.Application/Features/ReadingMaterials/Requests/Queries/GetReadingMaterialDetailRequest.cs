using SchoolManagement.Application.DTOs.ReadingMaterial;
using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialDetailRequest : IRequest<ReadingMaterialDto>
    {
        public int ReadingMaterialId { get; set; }
    }
}
