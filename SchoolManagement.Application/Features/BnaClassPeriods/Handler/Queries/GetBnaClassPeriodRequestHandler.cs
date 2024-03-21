using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassPeriods.Handler.Queries
{
    public class GetBnaClassPeriodRequestHandler : IRequestHandler<GetBnaClassPeriodRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassPeriod> _BnaClassPeriodRepository;


        public GetBnaClassPeriodRequestHandler(ISchoolManagementRepository<BnaClassPeriod> BnaClassPeriodRepository)
        {
            _BnaClassPeriodRepository = BnaClassPeriodRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetBnaClassPeriodRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaClassPeriod> bnaClassPeriods = _BnaClassPeriodRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);

            List<SelectedModel> selectModels = bnaClassPeriods.Select(x => new SelectedModel
            {
                Text = x.BnaClassPeriodName,
                Value = x.BnaClassPeriodId
            }).ToList();
            return selectModels;
        }
    }
}
