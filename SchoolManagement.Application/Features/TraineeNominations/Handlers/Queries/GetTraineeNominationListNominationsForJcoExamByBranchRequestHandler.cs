using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListNominationsForJcoExamByBranchRequestHandler : IRequestHandler<GetTraineeNominationListNominationsForJcoExamByBranchRequest, List<TraineeNominationDto>>
    {
         
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;

        private readonly IMapper _mapper;

        public GetTraineeNominationListNominationsForJcoExamByBranchRequestHandler(ISchoolManagementRepository<TraineeNomination> traineeNominationRepository, IMapper mapper)
        {
            _traineeNominationRepository = traineeNominationRepository; 
            _mapper = mapper;
        }

        public async Task<List<TraineeNominationDto>> Handle(GetTraineeNominationListNominationsForJcoExamByBranchRequest request, CancellationToken cancellationToken)
        {
            if (request.SaylorBranchId == 18 && request.SaylorSubBranchId == 22)
            {
                var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseDuration", "CourseName", "Trainee.Rank", "ExamCenter").OrderBy(x => x.Trainee.Pno);

                var traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);

                return traineeNominationDtos;
            }
            else
            {
                var traineeNominations = _traineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId && x.Trainee.SaylorBranchId == request.SaylorBranchId && x.Trainee.SaylorSubBranchId == request.SaylorSubBranchId, "CourseDuration", "CourseName", "Trainee.Rank", "ExamCenter").OrderBy(x => x.Trainee.Pno);

                var traineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(traineeNominations);

                return traineeNominationDtos;
            }
            
        }
    }
}
