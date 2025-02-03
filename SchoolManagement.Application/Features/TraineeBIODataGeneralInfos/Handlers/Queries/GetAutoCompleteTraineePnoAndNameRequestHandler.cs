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
    public class GetAutoCompleteTraineePnoAndNameRequestHandler : IRequestHandler< GetAutoCompleteTraineePnoAndName, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository; 

        public GetAutoCompleteTraineePnoAndNameRequestHandler(
            ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository,
            ISchoolManagementRepository<TraineeNomination> traineeNominationRepository
            )
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _traineeNominationRepository = traineeNominationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetAutoCompleteTraineePnoAndName request, CancellationToken cancellationToken)
        {
            var selectModels = new List<SelectedModel>();
            
            string concate = "";
            var pno = concate + request.PNo;

            if (pno.Length >= 3)
            {
                
                    ICollection<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfos = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x => x.IsActive && x.Pno.Contains(request.PNo));
                    selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                    {
                        Text = x.Pno + "_" + x.Name,
                        Value = x.TraineeId
                    }).ToList();
                    return selectModels;
                
               
        }
            return selectModels;
        }
    }
}
