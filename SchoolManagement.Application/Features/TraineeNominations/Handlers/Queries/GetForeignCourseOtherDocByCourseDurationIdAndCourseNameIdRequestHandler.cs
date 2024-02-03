using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequestHandler : IRequestHandler<GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequest, List<TraineeNominationDto>>
    { 
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;
        private readonly ISchoolManagementRepository<ForeignCourseOtherDoc> _foreignCourseOtherDocRepository;

        private readonly IMapper _mapper;

        public GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequestHandler(
            ISchoolManagementRepository<TraineeNomination> traineeNominationRepository,
            ISchoolManagementRepository<ForeignCourseOtherDoc> foreignCourseOtherDocRepository,
            IMapper mapper)
        {
            _traineeNominationRepository = traineeNominationRepository;
            _foreignCourseOtherDocRepository = foreignCourseOtherDocRepository;
            _mapper = mapper;
        }

        public async Task<List<TraineeNominationDto>> Handle(GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            var traineeNominationDtos = new List<TraineeNominationDto>();
            var traineeNomination = new List<TraineeNomination>();

            var foreignCourseOtherDoc = _foreignCourseOtherDocRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId).ToList();
           
            traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(foreignCourseOtherDoc);

            var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId).ToList();


            foreach (var item in traineeNominations)
            {
                //traineeNomination = traineeNominations.Where(x => x.TraineeId == item.TraineeId && x.TraineeNominationId == item.TraineeNominationId).ToList();
                foreach (var item1 in traineeNominationDtos)
                {
                    if (item.CourseDurationId==item1.CourseDurationId && item.CourseNameId==item1.CourseNameId && item1.TraineeId != item.TraineeId && item1.TraineeNominationId != item.TraineeNominationId)
                    {
                        traineeNomination.Add(item);
                    }
                }
            }
            //foreach (var item in traineeNominationDtos)
            //{
            //}

            // var traineeNomination = traineeNominations.Where(y => traineeNominationDtos.Any(z => z.TraineeNominationId !=y.TraineeNominationId && z.TraineeId != y.TraineeId));

            //foreach (var item in traineeNominations)
            //{

            //}
            // var isDifferent=traineeNominations.Where(x => !foreignCourseOtherDoc.Any(y => y.TraineeNominationId == x.TraineeNominationId)).Any();
            //// var isNotDifferent = traineeNominations.Zip(foreignCourseOtherDoc, (j, k) => j.TraineeNominationId == k.TraineeNominationId).Any(m => !m);

            // if (!isDifferent)
            // {
            //     foreignCourseOtherDoc = _foreignCourseOtherDocRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank").OrderBy(x => x.Trainee.Pno).ToList();
            //     traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(foreignCourseOtherDoc);
            // }
            // else
            // {
            //     traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank", "ExamCenter").OrderBy(x => x.Trainee.Pno).ToList();
            //     traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);
            // }

            return traineeNominationDtos; 
        } 
    }
}
