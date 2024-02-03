using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialByTypeListSpRequest : IRequest<object>
    {
        public int DocumentTypeId { get; set; }
    }
}
