using AutoMapper;
using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.Features.GameSports.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Queries
{
    public class GetGameSportDetailRequestHandler : IRequestHandler<GetGameSportDetailRequest, GameSportDto>
    {
       // private readonly IGameSportRepository _GameSportRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GameSport> _GameSportRepository;
        public GetGameSportDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GameSport>  GameSportRepository, IMapper mapper)
        {
            _GameSportRepository = GameSportRepository;
            _mapper = mapper;
        }
        public async Task<GameSportDto> Handle(GetGameSportDetailRequest request, CancellationToken cancellationToken)
        {
            var GameSport = await _GameSportRepository.FindOneAsync(x => x.GameSportId == request.GameSportId, "Game");
            return _mapper.Map<GameSportDto>(GameSport);
        }
    }
}
