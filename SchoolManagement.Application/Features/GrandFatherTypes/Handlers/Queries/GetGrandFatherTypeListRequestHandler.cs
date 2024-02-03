using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFatherType;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Queries
{
    public class GetGrandFatherTypeListRequestHandler : IRequestHandler<GetGrandFatherTypeListRequest, PagedResult<GrandFatherTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GrandFatherType> _GrandFatherTypeRepository;

        private readonly IMapper _mapper;

        public GetGrandFatherTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GrandFatherType> GrandFatherTypeRepository, IMapper mapper)
        {
            _GrandFatherTypeRepository = GrandFatherTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GrandFatherTypeDto>> Handle(GetGrandFatherTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GrandFatherType> GrandFatherTypes = _GrandFatherTypeRepository.FilterWithInclude(x => (x.GrandfatherTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = GrandFatherTypes.Count();
            GrandFatherTypes = GrandFatherTypes.OrderByDescending(x => x.GrandfatherTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GrandFatherTypeDtos = _mapper.Map<List<GrandFatherTypeDto>>(GrandFatherTypes);
            var result = new PagedResult<GrandFatherTypeDto>(GrandFatherTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
