using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Queries
{
    public class GetSelectedTdecActionStatusRequestHandler : IRequestHandler<GetSelectedTdecActionStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TdecActionStatus> _TdecActionStatusRepository;


        public GetSelectedTdecActionStatusRequestHandler(ISchoolManagementRepository<TdecActionStatus> TdecActionStatusRepository)
        {
            _TdecActionStatusRepository = TdecActionStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTdecActionStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<TdecActionStatus> codeValues = await _TdecActionStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.TdecActionStatusId
            }).ToList();
            return selectModels;
        }
    }
}
