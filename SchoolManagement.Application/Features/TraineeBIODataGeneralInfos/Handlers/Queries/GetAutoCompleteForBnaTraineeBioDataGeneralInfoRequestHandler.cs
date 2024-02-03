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
    public class GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequestHandler : IRequestHandler<GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository; 

        public GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequestHandler(
            ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository,
            ISchoolManagementRepository<TraineeNomination> traineeNominationRepository
            )
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _traineeNominationRepository = traineeNominationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequest request, CancellationToken cancellationToken)
        {
            var selectModels = new List<SelectedModel>();
            var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.BnaSemesterDurationId == request.BnaSemesterDurationId && x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId && x.Trainee.Pno == request.PNo, "Trainee").ToList();

            string concate = "";
            var pno = concate + request.PNo;

            if (pno.Length >= 3)
            {
                if (traineeNominations.Count <= 0)
                {
                    ICollection<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfos = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x => x.IsActive && x.Pno.Contains(request.PNo));
                    selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                    {
                        Text = x.Pno + "_" + x.Name,
                        Value = x.TraineeId
                    }).ToList();
                    return selectModels;
                }
                else
                {
                    foreach (var traineeNomination in traineeNominations)
                    {
                        ICollection<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfos = await _TraineeBioDataGeneralInfoRepository.FilterAsync(x => x.IsActive && x.LocalNominationStatus == 0 && x.Pno != traineeNomination.Trainee.Pno && x.Pno.Contains(request.PNo));

                        selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                        {
                            Text = x.Pno + "_" + x.Name,
                            Value = x.TraineeId
                        }).ToList();
                    }
                }
        }
            return selectModels;
        }
    }
}
