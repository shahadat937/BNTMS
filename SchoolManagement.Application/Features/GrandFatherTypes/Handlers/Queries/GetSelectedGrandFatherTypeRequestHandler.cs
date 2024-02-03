using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Queries
{
    public class GetSelectedGrandFatherTypeRequestHandler : IRequestHandler<GetSelectedGrandFatherTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GrandFatherType> _GrandFatherTypeRepository;


        public GetSelectedGrandFatherTypeRequestHandler(ISchoolManagementRepository<GrandFatherType> GrandFatherTypeRepository)
        {
            _GrandFatherTypeRepository = GrandFatherTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGrandFatherTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<GrandFatherType> codeValues = await _GrandFatherTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.GrandfatherTypeName,
                Value = x.GrandfatherTypeId
            }).ToList();
            return selectModels;
        }
    }
}
