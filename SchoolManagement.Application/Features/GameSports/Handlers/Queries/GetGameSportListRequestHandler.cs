using AutoMapper;
using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.Features.GameSports.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Queries
{
    public class GetGameSportListRequestHandler : IRequestHandler<GetGameSportListRequest, PagedResult<GameSportDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GameSport> _GameSportRepository;

        private readonly IMapper _mapper;

        public GetGameSportListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GameSport> GameSportRepository, IMapper mapper)
        {
            _GameSportRepository = GameSportRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GameSportDto>> Handle(GetGameSportListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GameSport> GameSports = _GameSportRepository.FilterWithInclude(x => (x.LevelOfParticipation.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Game");
            var totalCount = GameSports.Count();
            GameSports = GameSports.OrderByDescending(x => x.GameSportId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GameSportDtos = _mapper.Map<List<GameSportDto>>(GameSports);
            var result = new PagedResult<GameSportDto>(GameSportDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
