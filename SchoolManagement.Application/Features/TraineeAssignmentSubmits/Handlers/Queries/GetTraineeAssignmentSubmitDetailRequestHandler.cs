using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Queries
{
    public class GetTraineeAssignmentSubmitDetailRequestHandler : IRequestHandler<GetTraineeAssignmentSubmitDetailRequest, TraineeAssignmentSubmitDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssignmentSubmit> _TraineeAssignmentSubmitRepository;
        public GetTraineeAssignmentSubmitDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssignmentSubmit> TraineeAssignmentSubmitRepository, IMapper mapper)
        {
            _TraineeAssignmentSubmitRepository = TraineeAssignmentSubmitRepository;
            _mapper = mapper;
        }
        public async Task<TraineeAssignmentSubmitDto> Handle(GetTraineeAssignmentSubmitDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeAssignmentSubmit = await _TraineeAssignmentSubmitRepository.Get(request.TraineeAssignmentSubmitId);
            return _mapper.Map<TraineeAssignmentSubmitDto>(TraineeAssignmentSubmit);
        }
    }
}
