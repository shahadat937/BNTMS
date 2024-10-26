using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialsByTypeListSpRequest : IRequest<object>
    {
        public int DocumentTypeId { get; set; }
        public int SchoolId { get; set; }
    }
}
