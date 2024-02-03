using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Games;
using SchoolManagement.Application.Features.Games.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Games.Handlers.Queries
{
    public class GetGamesDetailRequestHandler : IRequestHandler<GetGameDetailRequest, GameDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Game> _GameRepository;       
        public GetGamesDetailRequestHandler(ISchoolManagementRepository<Game> GameRepository, IMapper mapper)
        {
            _GameRepository = GameRepository;    
            _mapper = mapper; 
        } 
        public async Task<GameDto> Handle(GetGameDetailRequest request, CancellationToken cancellationToken)
        {
            var Game = await _GameRepository.Get(request.Id);    
            return _mapper.Map<GameDto>(Game);    
        }
    }
}
