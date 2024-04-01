using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;
using System.Collections;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequestHandler : IRequestHandler<GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<Rank> _rankRepository;
        private readonly ISchoolManagementRepository<BnaSubjectCurriculum> _bnaSubjectCurriculumRepository;
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;
         
        public GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, ISchoolManagementRepository<Rank> rankRepository, ISchoolManagementRepository<BnaSubjectCurriculum> bnaSubjectCurriculumRepository, ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _rankRepository = rankRepository;
            _bnaSubjectCurriculumRepository = bnaSubjectCurriculumRepository;
            _courseDurationRepository = courseDurationRepository;
        }

        public async Task<object> Handle(GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequest request, CancellationToken cancellationToken)
        {

            List<TraineeNoinationModel> selectModels = new List<TraineeNoinationModel>();

            IQueryable<TraineeNomination> traineeNominations = _studentInfoByTraineeIdRepository.Where(x => x.BnaSemesterDurationId == request.BnaSemesterDurationId);

            if (traineeNominations.Any())
            {
                foreach (var item in traineeNominations)
                {
                    var pno = _traineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item.TraineeId).Select(x => x.Pno).FirstOrDefault();
                    var name = _traineeBioDataGeneralInfoRepository.Where(x=> x.TraineeId == item.TraineeId).Select(x=>x.Name).FirstOrDefault();
                    var rank = _rankRepository.Where(x => x.RankId == item.RankId).Select(x => x.Position).FirstOrDefault();
                    var curriculumName = _bnaSubjectCurriculumRepository.Where(x => x.BnaSubjectCurriculumId == item.BnaSubjectCurriculumId).Select(x => x.SubjectCurriculumName).FirstOrDefault();
                    var baseSchoolNameId = _courseDurationRepository.Where(x => x.CourseDurationId == item.CourseDurationId).Select(x => x.BaseSchoolNameId).FirstOrDefault();
                    TraineeNoinationModel getTraineeNoinationModel = new TraineeNoinationModel
                    {
                        pNo = pno,
                        pName = name,
                        Rank = rank,
                        Curriculum = curriculumName,
                        traineeNominationId = item.TraineeNominationId,
                        baseSchoolNameId = baseSchoolNameId,
                        courseDurationId = item.CourseDurationId,
                        traineeId = item.TraineeId

                    };
                    selectModels.Add(getTraineeNoinationModel);
                }
            }

            return selectModels;

            //var spQuery = String.Format("exec [spGetTraineeNominationListForBnaByBnaSemesterDurationId] {0}", request.BnaSemesterDurationId);

            //DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            //return dataTable;

        }
        public class TraineeNoinationModel{
            public object pNo { get; set; }
            public object pName { get; set; }
            public object Rank { get; set; }
            public object Curriculum { get; set; }
            public object traineeNominationId { get; set; }
            public object baseSchoolNameId { get; set; }
            public object courseDurationId { get; set; }
            public object traineeId { get; set; }
        }
    }
}
