using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListForAttendanceByCourseDurationIdRequestHandler : IRequestHandler<GetTraineeNominationListForAttendanceByCourseDurationIdRequest, List<TraineeNominationDto>>
    {
         
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;

        private readonly IMapper _mapper;

        public GetTraineeNominationListForAttendanceByCourseDurationIdRequestHandler(ISchoolManagementRepository<TraineeNomination> traineeNominationRepository, IMapper mapper)
        {
            _traineeNominationRepository = traineeNominationRepository; 
            _mapper = mapper;
        }

        public async Task<List<TraineeNominationDto>> Handle(GetTraineeNominationListForAttendanceByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            if(request.CourseSectionId == 0)
            {
                var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId , "WithdrawnType", "CourseDuration", "CourseName", "Trainee.Rank", "Trainee.SaylorRank", "ExamCenter").OrderBy(x => x.Trainee.Pno);

                var traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);

                return traineeNominationDtos;
            }
            else
            {
                var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId , "WithdrawnType", "CourseDuration", "CourseName", "Trainee.Rank", "Trainee.SaylorRank", "ExamCenter").OrderBy(x => x.Trainee.Pno);

                var traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);

                return traineeNominationDtos;
            }
            
        }
    }
}
