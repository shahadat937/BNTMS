using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.Features.Favorite.Requests.Queries;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Queries
{

    public class GetFavoritesListByTraineeRequestHandler : IRequestHandler<GetFavoritesListByTraineeRequest, List<FavoritesDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<Favorites> _FavoritesRepository;
        public GetFavoritesListByTraineeRequestHandler(ISchoolManagementRepository<Favorites> FavoritesRepository, IMapper mapper)
        {
            _FavoritesRepository = FavoritesRepository;
            _mapper = mapper;
        }
        public async Task<List<FavoritesDto>> Handle(GetFavoritesListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var Favorites = _FavoritesRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid, "FavoritesType");
            return _mapper.Map<List<FavoritesDto>>(Favorites);
        }
    }
}
