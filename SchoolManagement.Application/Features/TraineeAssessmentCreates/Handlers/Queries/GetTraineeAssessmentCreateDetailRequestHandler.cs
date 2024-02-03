using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Queries
{
    public class GetTraineeAssessmentCreateDetailRequestHandler : IRequestHandler<GetTraineeAssessmentCreateDetailRequest, TraineeAssessmentCreateDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentCreate> _TraineeAssessmentCreateRepository;
        public GetTraineeAssessmentCreateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentCreate> TraineeAssessmentCreateRepository, IMapper mapper)
        {
            _TraineeAssessmentCreateRepository = TraineeAssessmentCreateRepository;
            _mapper = mapper;
        }
        public async Task<TraineeAssessmentCreateDto> Handle(GetTraineeAssessmentCreateDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeAssessmentCreate = await _TraineeAssessmentCreateRepository.Get(request.TraineeAssessmentCreateId);
            return _mapper.Map<TraineeAssessmentCreateDto>(TraineeAssessmentCreate);
        }
    }
}
