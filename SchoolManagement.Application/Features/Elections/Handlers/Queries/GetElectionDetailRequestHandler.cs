using AutoMapper;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.Features.Elections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Elections.Handlers.Queries
{
    public class GetElectionDetailRequestHandler : IRequestHandler<GetElectionDetailRequest, ElectionDto>
    {
       // private readonly IElectionRepository _ElectionRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Election> _ElectionRepository;
        public GetElectionDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Election>  ElectionRepository, IMapper mapper)
        {
            _ElectionRepository = ElectionRepository;
            _mapper = mapper;
        }
        public async Task<ElectionDto> Handle(GetElectionDetailRequest request, CancellationToken cancellationToken)
        {
            var Election = await _ElectionRepository.FindOneAsync(x => x.ElectionId == request.ElectionId, "Elected");
            return _mapper.Map<ElectionDto>(Election);
        }
    }
}
