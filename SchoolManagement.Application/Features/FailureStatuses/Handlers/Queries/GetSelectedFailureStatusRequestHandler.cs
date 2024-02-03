using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Queries
{
    public class GetSelectedFailureStatusRequestHandler : IRequestHandler<GetSelectedFailureStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FailureStatus> _FailureStatusRepository;


        public GetSelectedFailureStatusRequestHandler(ISchoolManagementRepository<FailureStatus> FailureStatusRepository)
        {
            _FailureStatusRepository = FailureStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFailureStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<FailureStatus> codeValues = await _FailureStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FailureStatusName, 
                Value = x.FailureStatusId 
            }).ToList();
            return selectModels;
        }
    }
}
