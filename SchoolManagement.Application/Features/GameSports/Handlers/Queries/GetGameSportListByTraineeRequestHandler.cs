using AutoMapper;
using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.Features.GameSports.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Queries
{
    //public class GetGameSportListByTraineeRequestHandler : IRequestHandler<GetGameSportListByTraineeRequest, Unit>


    public class GetGameSportListByTraineeRequestHandler : IRequestHandler<GetGameSportListByTraineeRequest, List<GameSportDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GameSport> _GameSportRepository;
        public GetGameSportListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GameSport> GameSportRepository, IMapper mapper)
        {
            _GameSportRepository = GameSportRepository;
            _mapper = mapper;
        }
        public async Task<List<GameSportDto>> Handle(GetGameSportListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var GameSport = _GameSportRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "Game");
            return _mapper.Map<List<GameSportDto>>(GameSport);
        }
    }
}
