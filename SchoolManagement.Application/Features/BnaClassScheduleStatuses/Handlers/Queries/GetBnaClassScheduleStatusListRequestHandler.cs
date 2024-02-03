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
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Handlers.Queries
{
    public class GetBnaClassScheduleStatusListRequestHandler : IRequestHandler<GetBnaClassScheduleStatusListRequest, PagedResult<BnaClassScheduleStatusDto>>
    {

        private readonly ISchoolManagementRepository<BnaClassScheduleStatus> _BnaClassScheduleStatusRepository;

        private readonly IMapper _mapper;

        public GetBnaClassScheduleStatusListRequestHandler(ISchoolManagementRepository<BnaClassScheduleStatus> BnaClassScheduleStatusRepository, IMapper mapper)
        {
            _BnaClassScheduleStatusRepository = BnaClassScheduleStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaClassScheduleStatusDto>> Handle(GetBnaClassScheduleStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaClassScheduleStatus> BnaClassScheduleStatuss = _BnaClassScheduleStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaClassScheduleStatuss.Count();
            BnaClassScheduleStatuss = BnaClassScheduleStatuss.OrderByDescending(x => x.BnaClassScheduleStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaClassScheduleStatusDtos = _mapper.Map<List<BnaClassScheduleStatusDto>>(BnaClassScheduleStatuss);
            var result = new PagedResult<BnaClassScheduleStatusDto>(BnaClassScheduleStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
