using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Queries
{
    public class GetSelectedBnaClassTestTypeRequestHandler : IRequestHandler<GetSelectedBnaClassTestTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassTestType> _BnaClassTestTypeRepository;


        public GetSelectedBnaClassTestTypeRequestHandler(ISchoolManagementRepository<BnaClassTestType> BnaClassTestTypeRepository)
        {
            _BnaClassTestTypeRepository = BnaClassTestTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaClassTestTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaClassTestType> BnaClassTestTypes = await _BnaClassTestTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = BnaClassTestTypes.Select(x => new SelectedModel 
            {
                Text = x.Name,
                Value = x.BnaClassTestTypeId
            }).ToList();
            return selectModels;
        }
    }
}
