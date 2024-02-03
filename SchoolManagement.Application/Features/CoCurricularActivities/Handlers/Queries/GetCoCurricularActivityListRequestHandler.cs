using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries;
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

namespace SchoolManagement.Application.Features.CoCurricularActivities.Handlers.Queries
{
    public class GetCoCurricularActivityListRequestHandler : IRequestHandler<GetCoCurricularActivityListRequest, PagedResult<CoCurricularActivityDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity> _CoCurricularActivityRepository;

        private readonly IMapper _mapper;

        public GetCoCurricularActivityListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity> CoCurricularActivityRepository, IMapper mapper)
        {
            _CoCurricularActivityRepository = CoCurricularActivityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CoCurricularActivityDto>> Handle(GetCoCurricularActivityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CoCurricularActivity> CoCurricularActivitys = _CoCurricularActivityRepository.FilterWithInclude(x => (x.Participation.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CoCurricularActivitys.Count();
            CoCurricularActivitys = CoCurricularActivitys.OrderByDescending(x => x.CoCurricularActivityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CoCurricularActivityDtos = _mapper.Map<List<CoCurricularActivityDto>>(CoCurricularActivitys);
            var result = new PagedResult<CoCurricularActivityDto>(CoCurricularActivityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
