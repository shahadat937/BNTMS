using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Queries
{
    public class GetSelectedWithdrawnTypeRequestHandler : IRequestHandler<GetSelectedWithdrawnTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<WithdrawnType> _WithdrawnTypeRepository;


        public GetSelectedWithdrawnTypeRequestHandler(ISchoolManagementRepository<WithdrawnType> WithdrawnTypeRepository)
        {
            _WithdrawnTypeRepository = WithdrawnTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedWithdrawnTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<WithdrawnType> WithdrawnTypes = await _WithdrawnTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = WithdrawnTypes.Select(x => new SelectedModel 
            {
                Text = x.Name,
                Value = x.WithdrawnTypeId
            }).ToList();
            return selectModels;
        }
    }
}
