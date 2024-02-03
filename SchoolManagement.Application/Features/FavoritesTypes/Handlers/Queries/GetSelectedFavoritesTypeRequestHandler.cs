using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Queries
{ 
    public class GetSelectedFavoritesTypeRequestHandler : IRequestHandler<GetSelectedFavoritesTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FavoritesType> _FavoritesTypeRepository;


        public GetSelectedFavoritesTypeRequestHandler(ISchoolManagementRepository<FavoritesType> FavoritesTypeRepository)
        {
            _FavoritesTypeRepository = FavoritesTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFavoritesTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<FavoritesType> FavoritesTypes = await _FavoritesTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = FavoritesTypes.Select(x => new SelectedModel 
            {
                Text = x.FavoritesTypeName,
                Value = x.FavoritesTypeId 
            }).ToList();
            return selectModels;
        }
    }
}
