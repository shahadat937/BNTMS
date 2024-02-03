using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetPresentBilletRequestHandler : IRequestHandler<GetPresentBilletRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;

           
        public GetPresentBilletRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetPresentBilletRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos = _TraineeBioDataGeneralInfoRepository.FilterWithInclude(x =>x.TraineeId==request.TraineeId); 
            List<SelectedModel> selectModels = TraineeBioDataGeneralInfos.Select(x => new SelectedModel 
            {
                Text = x.PresentBillet,
                Value = x.TraineeId 
            }).ToList();
            return selectModels;
        }
    }
}
