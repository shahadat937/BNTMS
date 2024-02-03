using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Handlers.Queries
{
    public class GetSelectedBnaClassScheduleStatusRequestHandler : IRequestHandler<GetSelectedBnaClassScheduleStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassScheduleStatus> _BnaClassScheduleStatusRepository;


        public GetSelectedBnaClassScheduleStatusRequestHandler(ISchoolManagementRepository<BnaClassScheduleStatus> BnaClassScheduleStatusRepository)
        {
            _BnaClassScheduleStatusRepository = BnaClassScheduleStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaClassScheduleStatusRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _BnaClassScheduleStatusRepository.FilterWithInclude(x => x.IsActive).OrderBy(x => x.MenuPosition);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.BnaClassScheduleStatusId
            }).ToList();
            return selectModels;
        }
    }
}
