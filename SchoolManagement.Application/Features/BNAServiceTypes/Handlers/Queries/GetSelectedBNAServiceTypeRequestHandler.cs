using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Queries
{ 
    public class GetSelectedBnaServiceTypeRequestHandler : IRequestHandler<GetSelectedBnaServiceTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaServiceType> _BnaServiceTypeRepository;


        public GetSelectedBnaServiceTypeRequestHandler(ISchoolManagementRepository<BnaServiceType> BnaServiceTypeRepository)
        {
            _BnaServiceTypeRepository = BnaServiceTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaServiceTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaServiceType> bnaServiceTypes = await _BnaServiceTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = bnaServiceTypes.Select(x => new SelectedModel 
            {
                Text = x.ServiceName,
                Value = x.BnaServiceTypeId
            }).ToList();
            return selectModels;
        }
    }
} 
