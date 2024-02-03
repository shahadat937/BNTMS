using SchoolManagement.Application.Features.OrganizationNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OrganizationName;
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


namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Queries
{
    public class GetOrganizationNameListRequestHandler : IRequestHandler<GetOrganizationNameListRequest, PagedResult<OrganizationNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OrganizationName> _OrganizationNameRepository;

        private readonly IMapper _mapper;

        public GetOrganizationNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.OrganizationName> OrganizationNameRepository, IMapper mapper)
        {
            _OrganizationNameRepository = OrganizationNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OrganizationNameDto>> Handle(GetOrganizationNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.OrganizationName> OrganizationNames = _OrganizationNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "ForceType");
            var totalCount = OrganizationNames.Count();
            OrganizationNames = OrganizationNames.OrderByDescending(x => x.OrganizationNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OrganizationNameDtos = _mapper.Map<List<OrganizationNameDto>>(OrganizationNames);
            var result = new PagedResult<OrganizationNameDto>(OrganizationNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
