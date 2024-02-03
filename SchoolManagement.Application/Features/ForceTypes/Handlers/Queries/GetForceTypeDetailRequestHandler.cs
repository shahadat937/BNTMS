using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForceType;
using SchoolManagement.Application.Features.ForceTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForceTypes.Handlers.Queries
{
    public class GetForceTypeDetailRequestHandler : IRequestHandler<GetForceTypeDetailRequest, ForceTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForceType> _ForceTypeRepository;
        public GetForceTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForceType> ForceTypeRepository, IMapper mapper)
        {
            _ForceTypeRepository = ForceTypeRepository;
            _mapper = mapper;
        }
        public async Task<ForceTypeDto> Handle(GetForceTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ForceType = await _ForceTypeRepository.Get(request.ForceTypeId);
            return _mapper.Map<ForceTypeDto>(ForceType);
        }
    }
}
