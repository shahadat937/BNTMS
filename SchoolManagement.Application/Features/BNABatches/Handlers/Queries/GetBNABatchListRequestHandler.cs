using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.Features.BnaBatches.Requests.Queries;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Queries
{
    public class GetBnaBatchListRequestHandler : IRequestHandler<GetBnaBatchListRequest, PagedResult<BnaBatchDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaBatch> _BnaBatchRepository;

        private readonly IMapper _mapper;

        public GetBnaBatchListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaBatch> BnaBatchRepository, IMapper mapper)
        {
            _BnaBatchRepository = BnaBatchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaBatchDto>> Handle(GetBnaBatchListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaBatch> BnaBatches = _BnaBatchRepository.FilterWithInclude(x => x.BnaBatchId != 282 && (x.BatchName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaBatches.Count();
            BnaBatches = BnaBatches.OrderByDescending(x => x.BnaBatchId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaBatchDtos = _mapper.Map<List<BnaBatchDto>>(BnaBatches);
            var result = new PagedResult<BnaBatchDto>(BnaBatchDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
