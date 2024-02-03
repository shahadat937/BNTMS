using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Queries
{
    public class GetSelectedResultStatusRequestHandler : IRequestHandler<GetSelectedResultStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ResultStatus> _ResultStatusRepository;


        public GetSelectedResultStatusRequestHandler(ISchoolManagementRepository<ResultStatus> ResultStatusRepository)
        {
            _ResultStatusRepository = ResultStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedResultStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<ResultStatus> codeValues = await _ResultStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ResultStatusName,
                Value = x.ResultStatusId
            }).ToList();
            return selectModels;
        }
    }
}
