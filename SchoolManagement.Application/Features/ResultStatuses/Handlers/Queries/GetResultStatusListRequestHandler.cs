using SchoolManagement.Application.Features.ResultStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ResultStatus;
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

using System.Text;


namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Queries
{
    public class GetResultStatusListRequestHandler : IRequestHandler<GetResultStatusListRequest, PagedResult<ResultStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ResultStatus> _ResultStatusRepository;

        private readonly IMapper _mapper;

        public GetResultStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ResultStatus> ResultStatusRepository, IMapper mapper)
        {
            _ResultStatusRepository = ResultStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ResultStatusDto>> Handle(GetResultStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ResultStatus> ResultStatuses = _ResultStatusRepository.FilterWithInclude(x => (x.ResultStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ResultStatuses.Count();
            ResultStatuses = ResultStatuses.OrderByDescending(x => x.ResultStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ResultStatusDtos = _mapper.Map<List<ResultStatusDto>>(ResultStatuses);
            var result = new PagedResult<ResultStatusDto>(ResultStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
