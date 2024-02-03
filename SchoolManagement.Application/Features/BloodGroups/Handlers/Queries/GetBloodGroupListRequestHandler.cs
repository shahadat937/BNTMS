using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BloodGroup;
using SchoolManagement.Application.Features.BloodGroups.Requests;
using SchoolManagement.Application.Features.BloodGroups.Requests.Queries;
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

namespace SchoolManagement.Application.Features.BloodGroups.Handlers.Queries
{
    public class GetBloodGroupListRequestHandler : IRequestHandler<GetBloodGroupListRequest, PagedResult<BloodGroupDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BloodGroup> _BloodGroupRepository;

        private readonly IMapper _mapper;

        public GetBloodGroupListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BloodGroup> BloodGroupRepository, IMapper mapper)
        {
            _BloodGroupRepository = BloodGroupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BloodGroupDto>> Handle(GetBloodGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BloodGroup> BloodGroups = _BloodGroupRepository.FilterWithInclude(x => x.BloodGroupId != 26 && (x.BloodGroupName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BloodGroups.Count();
            BloodGroups = BloodGroups.OrderByDescending(x => x.BloodGroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BloodGroupDtos = _mapper.Map<List<BloodGroupDto>>(BloodGroups);
            var result = new PagedResult<BloodGroupDto>(BloodGroupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
