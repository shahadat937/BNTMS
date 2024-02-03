using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdRequestHandler : IRequestHandler<GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdRequest, List<TraineeNominationDto>>
    { 
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;
        private readonly ISchoolManagementRepository<ForeignCourseOtherDoc> _foreignCourseOtherDocRepository;

        private readonly IMapper _mapper;

        public GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdRequestHandler(
            ISchoolManagementRepository<TraineeNomination> traineeNominationRepository,
            ISchoolManagementRepository<ForeignCourseOtherDoc> foreignCourseOtherDocRepository,
            IMapper mapper)
        {
            _traineeNominationRepository = traineeNominationRepository;
            _foreignCourseOtherDocRepository = foreignCourseOtherDocRepository;
            _mapper = mapper;
        }

        public async Task<List<TraineeNominationDto>> Handle(GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            var traineeNominationDtos = new List<TraineeNominationDto>();

            var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank", "ExamCenter").OrderBy(x => x.Trainee.Pno).ToList();
            var foreignCourseOtherDoc = _foreignCourseOtherDocRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank").OrderBy(x => x.Trainee.Pno).ToList();

            traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(foreignCourseOtherDoc);
            traineeNominationDtos.AddRange(_mapper.Map<List<TraineeNominationDto>>(traineeNominations));
            traineeNominationDtos = traineeNominationDtos.DistinctBy(x =>x.TraineeNominationId).ToList();
            // var isDifferent=traineeNominations.Where(x => !foreignCourseOtherDoc.Any(y => y.TraineeNominationId == x.TraineeNominationId)).Any();
            // var isNotDifferent = traineeNominations.Zip(foreignCourseOtherDoc, (j, k) => j.TraineeNominationId == k.TraineeNominationId).Any(m => !m);

            //if (!isDifferent)
            //{
            //    foreignCourseOtherDoc = _foreignCourseOtherDocRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank").OrderBy(x => x.Trainee.Pno).ToList();
            //    traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(foreignCourseOtherDoc);
            //}
            //else
            //{
            //    traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank", "ExamCenter").OrderBy(x => x.Trainee.Pno).ToList();
            //    traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);
            //}

            return traineeNominationDtos; 
        } 
    }
}
