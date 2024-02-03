using SchoolManagement.Application.Features.Ranks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.Ranks.Handlers.Queries
{
    public class GetRankListRequestHandler : IRequestHandler<GetRankListRequest, PagedResult<RankDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Rank> _RankRepository;

        private readonly IMapper _mapper;

        public GetRankListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Rank> RankRepository, IMapper mapper)
        {
            _RankRepository = RankRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RankDto>> Handle(GetRankListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Rank> Ranks = _RankRepository.FilterWithInclude(x => x.RankId != 23 && (x.RankName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Ranks.Count();
            Ranks = Ranks.OrderByDescending(x => x.RankId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RankDtos = _mapper.Map<List<RankDto>>(Ranks);
            var result = new PagedResult<RankDto>(RankDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
