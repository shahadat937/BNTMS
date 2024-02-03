using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Queries
{
    public class GetFavoritesTypeDetailRequestHandler : IRequestHandler<GetFavoritesTypeDetailRequest, FavoritesTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FavoritesType> _FavoritesTypeRepository;
        public GetFavoritesTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FavoritesType> FavoritesTypeRepository, IMapper mapper)
        {
            _FavoritesTypeRepository = FavoritesTypeRepository;
            _mapper = mapper;
        }
        public async Task<FavoritesTypeDto> Handle(GetFavoritesTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var FavoritesType = await _FavoritesTypeRepository.Get(request.FavoritesTypeId);
            return _mapper.Map<FavoritesTypeDto>(FavoritesType);
        }
    }
}
