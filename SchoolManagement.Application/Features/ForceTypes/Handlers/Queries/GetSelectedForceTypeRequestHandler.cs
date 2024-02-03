using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ForceTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForceTypes.Handlers.Queries
{
    public class GetSelectedForceTypeRequestHandler : IRequestHandler<GetSelectedForceTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ForceType> _ForceTypeRepository;


        public GetSelectedForceTypeRequestHandler(ISchoolManagementRepository<ForceType> ForceTypeRepository)
        {
            _ForceTypeRepository = ForceTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedForceTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ForceType> codeValues = await _ForceTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ForceTypeName,
                Value = x.ForceTypeId
            }).ToList();
            return selectModels;
        }
    }
}
