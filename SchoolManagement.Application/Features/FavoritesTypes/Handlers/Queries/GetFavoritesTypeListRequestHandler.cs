using SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Queries
{
    public class GetFavoritesTypeListRequestHandler : IRequestHandler<GetFavoritesTypeListRequest, PagedResult<FavoritesTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FavoritesType> _FavoritesTypeRepository;

        private readonly IMapper _mapper;

        public GetFavoritesTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FavoritesType> FavoritesTypeRepository, IMapper mapper)
        {
            _FavoritesTypeRepository = FavoritesTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FavoritesTypeDto>> Handle(GetFavoritesTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.FavoritesType> FavoritesTypes = _FavoritesTypeRepository.FilterWithInclude(x => (x.FavoritesTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = FavoritesTypes.Count();
            FavoritesTypes = FavoritesTypes.OrderByDescending(x => x.FavoritesTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FavoritesTypeDtos = _mapper.Map<List<FavoritesTypeDto>>(FavoritesTypes);
            var result = new PagedResult<FavoritesTypeDto>(FavoritesTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
