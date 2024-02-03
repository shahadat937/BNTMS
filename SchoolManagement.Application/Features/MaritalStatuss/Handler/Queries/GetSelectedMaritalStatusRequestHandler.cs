using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MaritalStatuss.Handlers.Queries
{
    public class GetSelectedMaritalStatusRequestHandler : IRequestHandler<GetSelectedMaritalStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaritalStatus> _MaritalStatusRepository;


        public GetSelectedMaritalStatusRequestHandler(ISchoolManagementRepository<MaritalStatus> MaritalStatusRepository)
        {
            _MaritalStatusRepository = MaritalStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaritalStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaritalStatus> codeValues = await _MaritalStatusRepository.FilterAsync(x => x.IsActive && x.MaritalStatusId != 14);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MaritalStatusName,
                Value = x.MaritalStatusId
            }).ToList();
            return selectModels;
        }
    }
}
