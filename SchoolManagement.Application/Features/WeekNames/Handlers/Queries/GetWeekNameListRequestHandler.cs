using SchoolManagement.Application.Features.WeekNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WeekName;
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


namespace SchoolManagement.Application.Features.WeekNames.Handlers.Queries
{
    public class GetWeekNameListRequestHandler : IRequestHandler<GetWeekNameListRequest, PagedResult<WeekNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.WeekName> _WeekNameRepository;

        private readonly IMapper _mapper;

        public GetWeekNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.WeekName> WeekNameRepository, IMapper mapper)
        {
            _WeekNameRepository = WeekNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<WeekNameDto>> Handle(GetWeekNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.WeekName> WeekNames = _WeekNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = WeekNames.Count();
            WeekNames = WeekNames.OrderByDescending(x => x.WeekNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var WeekNameDtos = _mapper.Map<List<WeekNameDto>>(WeekNames);
            var result = new PagedResult<WeekNameDto>(WeekNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
