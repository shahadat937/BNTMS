using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Queries
{
    public class GetSelectedFamilyInfoRequestHandler : IRequestHandler<GetSelectedFamilyInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FamilyInfo> _FamilyInfoRepository;


        public GetSelectedFamilyInfoRequestHandler(ISchoolManagementRepository<FamilyInfo> FamilyInfoRepository)
        {
            _FamilyInfoRepository = FamilyInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFamilyInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<FamilyInfo> FamilyInfos = await _FamilyInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = FamilyInfos.Select(x => new SelectedModel 
            {
                Text = x.FullName,
                Value = x.FamilyInfoId
            }).ToList();
            return selectModels;
        }
    }
}
