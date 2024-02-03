using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetSelectedTraineeBioDataGeneralInfoRequestHandler : IRequestHandler<GetSelectedTraineeBioDataGeneralInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;


        public GetSelectedTraineeBioDataGeneralInfoRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeBioDataGeneralInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<TraineeBioDataGeneralInfo> codeValues = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Pno,
                Value = x.TraineeId
            }).ToList();
            return selectModels;
        }
    }
}
