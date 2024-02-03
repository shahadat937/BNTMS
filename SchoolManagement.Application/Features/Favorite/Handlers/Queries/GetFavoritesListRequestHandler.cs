using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.Favorite.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Queries
{
    public class GetFavoritesListRequestHandler : IRequestHandler<GetFavoritesListRequest, PagedResult<FavoritesDto>>
    { 

        private readonly ISchoolManagementRepository<Favorites> _FavoritesRepository;    

        private readonly IMapper _mapper;  
         
        public GetFavoritesListRequestHandler(ISchoolManagementRepository<Favorites> FavoritesRepository, IMapper mapper)
        {
            _FavoritesRepository = FavoritesRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<FavoritesDto>> Handle(GetFavoritesListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Favorites> Favoritess = _FavoritesRepository.FilterWithInclude(x => (x.FavoritesName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Favoritess.Count();
            Favoritess = Favoritess.OrderByDescending(x => x.FavoritesId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var FavoritessDtos = _mapper.Map<List<FavoritesDto>>(Favoritess); 
            var result = new PagedResult<FavoritesDto>(FavoritessDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
