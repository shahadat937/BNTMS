using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialBySchoolSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
