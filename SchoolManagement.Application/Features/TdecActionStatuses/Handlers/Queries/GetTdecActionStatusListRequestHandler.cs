using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecActionStatus;
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

using System.Text;


namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Queries
{
    public class GetTdecActionStatusListRequestHandler : IRequestHandler<GetTdecActionStatusListRequest, PagedResult<TdecActionStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecActionStatus> _TdecActionStatusRepository;

        private readonly IMapper _mapper;

        public GetTdecActionStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecActionStatus> TdecActionStatusRepository, IMapper mapper)
        {
            _TdecActionStatusRepository = TdecActionStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TdecActionStatusDto>> Handle(GetTdecActionStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TdecActionStatus> TdecActionStatuss = _TdecActionStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TdecActionStatuss.Count();
            TdecActionStatuss = TdecActionStatuss.OrderByDescending(x => x.TdecActionStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TdecActionStatusDtos = _mapper.Map<List<TdecActionStatusDto>>(TdecActionStatuss);
            var result = new PagedResult<TdecActionStatusDto>(TdecActionStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
