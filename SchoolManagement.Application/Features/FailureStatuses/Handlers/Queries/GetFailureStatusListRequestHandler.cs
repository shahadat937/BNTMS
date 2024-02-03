using AutoMapper;
using SchoolManagement.Application.DTOs.FailureStatus;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Queries;
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

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Queries
{
    public class GetFailureStatusListRequestHandler : IRequestHandler<GetFailureStatusListRequest, PagedResult<FailureStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FailureStatus> _FailureStatusRepository;

        private readonly IMapper _mapper;

        public GetFailureStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FailureStatus> FailureStatusRepository, IMapper mapper)
        {
            _FailureStatusRepository = FailureStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FailureStatusDto>> Handle(GetFailureStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.FailureStatus> FailureStatuses = _FailureStatusRepository.FilterWithInclude(x => (x.FailureStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = FailureStatuses.Count();
            FailureStatuses = FailureStatuses.OrderByDescending(x => x.FailureStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FailureStatusDtos = _mapper.Map<List<FailureStatusDto>>(FailureStatuses);
            var result = new PagedResult<FailureStatusDto>(FailureStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
