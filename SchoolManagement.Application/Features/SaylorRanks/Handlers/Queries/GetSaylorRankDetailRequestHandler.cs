using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Queries
{
    public class GetSaylorRankDetailRequestHandler : IRequestHandler<GetSaylorRankDetailRequest, SaylorRankDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SaylorRank> _SaylorRankRepository;
        public GetSaylorRankDetailRequestHandler(ISchoolManagementRepository<SaylorRank> SaylorRankRepository, IMapper mapper)
        {
            _SaylorRankRepository = SaylorRankRepository;
            _mapper = mapper;
        }
        public async Task<SaylorRankDto> Handle(GetSaylorRankDetailRequest request, CancellationToken cancellationToken)
        {
            var SaylorRank = await _SaylorRankRepository.Get(request.SaylorRankId);
            return _mapper.Map<SaylorRankDto>(SaylorRank);
        }
    }
}
