using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialByBaseSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
    }
}
