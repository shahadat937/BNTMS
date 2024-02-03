using MediatR;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialByTraineeIdSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
