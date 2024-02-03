using AutoMapper;
using SchoolManagement.Application.DTOs.StepRelation;
using SchoolManagement.Application.Features.StepRelations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.StepRelations.Handlers.Queries
{
    public class GetStepRelationDetailRequestHandler : IRequestHandler<GetStepRelationDetailRequest, StepRelationDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.StepRelation> _StepRelationRepository;
        public GetStepRelationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.StepRelation> StepRelationRepository, IMapper mapper)
        {
            _StepRelationRepository = StepRelationRepository;
            _mapper = mapper;
        }
        public async Task<StepRelationDto> Handle(GetStepRelationDetailRequest request, CancellationToken cancellationToken)
        {
            var StepRelation = await _StepRelationRepository.Get(request.StepRelationId);
            return _mapper.Map<StepRelationDto>(StepRelation);
        }
    }
}
