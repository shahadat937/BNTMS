using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands
{
    public class DeleteReadingMaterialCommand : IRequest
    {
        public int ReadingMaterialId { get; set; }
    }
}
