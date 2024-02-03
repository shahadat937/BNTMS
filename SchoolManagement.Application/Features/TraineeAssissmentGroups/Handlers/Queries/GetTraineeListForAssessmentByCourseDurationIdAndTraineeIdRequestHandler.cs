using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Queries
{
    public class GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequestHandler : IRequestHandler<GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequest, List<TraineeAssissmentGroupDto>>
    {
         
        private readonly ISchoolManagementRepository<TraineeAssissmentGroup> _TraineeAssissmentGroupRepository;

        private readonly IMapper _mapper;

        public GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequestHandler(ISchoolManagementRepository<TraineeAssissmentGroup> TraineeAssissmentGroupRepository, IMapper mapper)
        {
            _TraineeAssissmentGroupRepository = TraineeAssissmentGroupRepository; 
            _mapper = mapper;
        }

        public async Task<List<TraineeAssissmentGroupDto>> Handle(GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var TraineeAssissmentGroups = _TraineeAssissmentGroupRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId && x.TraineeAssissmentCreateId == request.TraineeAssissmentCreateId && x.TraineeId != request.TraineeId, "Trainee", "Trainee.Rank", "Trainee.SaylorRank").OrderBy(x => x.Trainee.Pno);

            var TraineeAssissmentGroupDtos = _mapper.Map<List<TraineeAssissmentGroupDto>>(TraineeAssissmentGroups);

            return TraineeAssissmentGroupDtos;
            
            
        }
    }
}
