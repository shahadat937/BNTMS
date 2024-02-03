using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Games;
using SchoolManagement.Application.Features.Games.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Games.Handlers.Queries
{
    public class GetGameListRequestHandler : IRequestHandler<GetGameListRequest, PagedResult<GameDto>>
    { 

        private readonly ISchoolManagementRepository<Game> _GameRepository;    

        private readonly IMapper _mapper;  
         
        public GetGameListRequestHandler(ISchoolManagementRepository<Game> GameRepository, IMapper mapper)
        {
            _GameRepository = GameRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<GameDto>> Handle(GetGameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Game> Games = _GameRepository.FilterWithInclude(x => (x.GameName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Games.Count();
            Games = Games.OrderBy(x => x.GameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var GamesDtos = _mapper.Map<List<GameDto>>(Games); 
            var result = new PagedResult<GameDto>(GamesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
