using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.Features.Favorite.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Queries
{
    public class GetFavoritesDetailRequestHandler : IRequestHandler<GetFavoritesDetailRequest, FavoritesDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Favorites> _FavoritesRepository;       
        public GetFavoritesDetailRequestHandler(ISchoolManagementRepository<Favorites> FavoritesRepository, IMapper mapper)
        {
            _FavoritesRepository = FavoritesRepository;    
            _mapper = mapper; 
        } 
        public async Task<FavoritesDto> Handle(GetFavoritesDetailRequest request, CancellationToken cancellationToken)
        {
            var Favorites = await _FavoritesRepository.FindOneAsync(x => x.FavoritesId == request.Id, "FavoritesType");    
            return _mapper.Map<FavoritesDto>(Favorites);    
        }
    }
}
