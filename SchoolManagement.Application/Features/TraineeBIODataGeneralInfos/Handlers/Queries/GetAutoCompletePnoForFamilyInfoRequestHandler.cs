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
    public class GetAutoCompletePnoForFamilyInfoRequestHandler : IRequestHandler<GetAutoCompletePnoForFamilyInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository; 
        public GetAutoCompletePnoForFamilyInfoRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePnoForFamilyInfoRequest request, CancellationToken cancellationToken)
        {
                ICollection<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfos = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x => x.IsActive && x.Pno.Contains(request.Pno));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.Pno + "_" + x.Name,
                    Value = x.TraineeId
                }).ToList();
                return selectModels;
            }
      }
}
