using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetSelectedTraineeBioDataGeneralInfoByUserHandler : IRequestHandler<GetSelectedTraineeBioDataGeneralInfoByUser, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;


        public GetSelectedTraineeBioDataGeneralInfoByUserHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeBioDataGeneralInfoByUser request, CancellationToken cancellationToken)
        {
            ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x =>x.IsActive);
            List<SelectedModel> selectModels = TraineeBioDataGeneralInfos.Select(x => new SelectedModel
            {
                Text = x.Pno,
                Value = x.TraineeId
            }).ToList();
            return selectModels;
        }
    }
}
