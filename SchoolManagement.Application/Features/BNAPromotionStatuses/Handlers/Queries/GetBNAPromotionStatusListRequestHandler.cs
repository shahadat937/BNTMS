using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Handlers.Queries
{
    public class GetBnaPromotionStatusListRequestHandler : IRequestHandler<GetBnaPromotionStatusListRequest, PagedResult<BnaPromotionStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaPromotionStatus> _BnaPromotionStatusRepository;

        private readonly IMapper _mapper;

        public GetBnaPromotionStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaPromotionStatus> BnaPromotionStatusRepository, IMapper mapper)
        {
            _BnaPromotionStatusRepository = BnaPromotionStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaPromotionStatusDto>> Handle(GetBnaPromotionStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaPromotionStatus> BnaPromotionStatuses = _BnaPromotionStatusRepository.FilterWithInclude(x => (x.PromotionStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaPromotionStatuses.Count();
            BnaPromotionStatuses = BnaPromotionStatuses.OrderByDescending(x => x.BnaPromotionStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaPromotionStatusDtos = _mapper.Map<List<BnaPromotionStatusDto>>(BnaPromotionStatuses);
            var result = new PagedResult<BnaPromotionStatusDto>(BnaPromotionStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
