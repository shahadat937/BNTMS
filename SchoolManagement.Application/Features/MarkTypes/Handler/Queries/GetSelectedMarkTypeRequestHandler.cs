using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MarkTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MarkTypes.Handlers.Queries
{
    public class GetSelectedMarkTypeRequestHandler : IRequestHandler<GetSelectedMarkTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MarkType> _MarkTypeRepository;


        public GetSelectedMarkTypeRequestHandler(ISchoolManagementRepository<MarkType> MarkTypeRepository)
        {
            _MarkTypeRepository = MarkTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMarkTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<MarkType> codeValues = await _MarkTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.TypeName,
                Value = x.MarkTypeId
            }).ToList();
            return selectModels;
        }
    }
}
