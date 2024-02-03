using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DownloadRights.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Queries
{
    public class GetSelectedDownloadRightRequestHandler : IRequestHandler<GetSelectedDownloadRightRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DownloadRight> _DownloadRightRepository;


        public GetSelectedDownloadRightRequestHandler(ISchoolManagementRepository<DownloadRight> DownloadRightRepository)
        {
            _DownloadRightRepository = DownloadRightRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDownloadRightRequest request, CancellationToken cancellationToken)
        {
            ICollection<DownloadRight> codeValues = await _DownloadRightRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DownloadRightName,
                Value = x.DownloadRightId
            }).ToList();
            return selectModels;
        }
    }
}
