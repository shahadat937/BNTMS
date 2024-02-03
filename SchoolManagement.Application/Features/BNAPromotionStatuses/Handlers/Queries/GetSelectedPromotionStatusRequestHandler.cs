using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PromotionStatuses.Handlers.Queries
{ 
    public class GetSelectedPromotionStatusRequestHandler : IRequestHandler<GetSelectedBnaPromotionStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaPromotionStatus> _PromotionStatusRepository;


        public GetSelectedPromotionStatusRequestHandler(ISchoolManagementRepository<BnaPromotionStatus> PromotionStatusRepository)
        {
            _PromotionStatusRepository = PromotionStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaPromotionStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaPromotionStatus> PromotionStatuss = await _PromotionStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = PromotionStatuss.Select(x => new SelectedModel 
            {
                Text = x.PromotionStatusName,
                Value = x.BnaPromotionStatusId 
            }).ToList();
            return selectModels;
        }
    }
}
