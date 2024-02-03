using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Queries
{ 
    public class GetSelectedUtofficerTypeRequestHandler : IRequestHandler<GetSelectedUtofficerTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<UtofficerType> _UtofficerTypeRepository;


        public GetSelectedUtofficerTypeRequestHandler(ISchoolManagementRepository<UtofficerType> UtofficerTypeRepository)
        {
            _UtofficerTypeRepository = UtofficerTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedUtofficerTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<UtofficerType> UtofficerTypes = await _UtofficerTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = UtofficerTypes.Select(x => new SelectedModel 
            {
                Text = x.UtofficerTypeName,
                Value = x.UtofficerTypeId
            }).ToList();
            return selectModels;
        }
    }
}
