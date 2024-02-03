using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Queries
{
    public class GetTraineeAssessmentMarkDetailRequestHandler : IRequestHandler<GetTraineeAssessmentMarkDetailRequest, TraineeAssessmentMarkDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentMark> _TraineeAssessmentMarkRepository;
        public GetTraineeAssessmentMarkDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentMark> TraineeAssessmentMarkRepository, IMapper mapper)
        {
            _TraineeAssessmentMarkRepository = TraineeAssessmentMarkRepository;
            _mapper = mapper;
        }
        public async Task<TraineeAssessmentMarkDto> Handle(GetTraineeAssessmentMarkDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeAssessmentMark = await _TraineeAssessmentMarkRepository.Get(request.TraineeAssessmentMarkId);
            return _mapper.Map<TraineeAssessmentMarkDto>(TraineeAssessmentMark);
        }
    }
}
