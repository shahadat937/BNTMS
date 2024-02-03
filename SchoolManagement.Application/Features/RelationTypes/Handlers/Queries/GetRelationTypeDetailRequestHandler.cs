using AutoMapper;
using SchoolManagement.Application.DTOs.RelationType;
using SchoolManagement.Application.Features.RelationTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Queries
{
    public class GetRelationTypeDetailRequestHandler : IRequestHandler<GetRelationTypeDetailRequest, RelationTypeDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RelationType> _RelationTypeRepository;
        public GetRelationTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RelationType> RelationTypeRepository, IMapper mapper)
        {
            _RelationTypeRepository = RelationTypeRepository;
            _mapper = mapper;
        }
        public async Task<RelationTypeDto> Handle(GetRelationTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var RelationType = await _RelationTypeRepository.Get(request.RelationTypeId);
            return _mapper.Map<RelationTypeDto>(RelationType);
        }
    }
}
