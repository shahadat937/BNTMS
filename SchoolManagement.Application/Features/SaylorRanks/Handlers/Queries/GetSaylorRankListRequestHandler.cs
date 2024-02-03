using SchoolManagement.Application.Features.SaylorRanks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Queries
{
    public class GetSaylorRankListRequestHandler : IRequestHandler<GetSaylorRankListRequest, PagedResult<SaylorRankDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SaylorRank> _SaylorRankRepository;

        private readonly IMapper _mapper;

        public GetSaylorRankListRequestHandler(ISchoolManagementRepository<SaylorRank> SaylorRankRepository, IMapper mapper)
        {
            _SaylorRankRepository = SaylorRankRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SaylorRankDto>> Handle(GetSaylorRankListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SaylorRank> SaylorRanks = _SaylorRankRepository.FilterWithInclude(x =>x.SaylorRankId != 1011 && (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SaylorRanks.Count();
            SaylorRanks = SaylorRanks.OrderByDescending(x => x.SaylorRankId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SaylorRankDtos = _mapper.Map<List<SaylorRankDto>>(SaylorRanks);
            var result = new PagedResult<SaylorRankDto>(SaylorRankDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
