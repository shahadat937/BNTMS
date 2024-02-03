using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyInfo;
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

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Queries
{
    public class GetFamilyInfoListRequestHandler : IRequestHandler<GetFamilyInfoListRequest, PagedResult<FamilyInfoDto>>
    {

        private readonly ISchoolManagementRepository<FamilyInfo> _FamilyInfoRepository;

        private readonly IMapper _mapper;

        public GetFamilyInfoListRequestHandler(ISchoolManagementRepository<FamilyInfo> FamilyInfoRepository, IMapper mapper)
        {
            _FamilyInfoRepository = FamilyInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FamilyInfoDto>> Handle(GetFamilyInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<FamilyInfo> FamilyInfos = _FamilyInfoRepository.FilterWithInclude(x => (x.FullName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Trainee", "RelationType", "Trainee.Rank");
            var totalCount = FamilyInfos.Count();
            FamilyInfos = FamilyInfos.OrderByDescending(x => x.FamilyInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FamilyInfoDtos = _mapper.Map<List<FamilyInfoDto>>(FamilyInfos);
            var result = new PagedResult<FamilyInfoDto>(FamilyInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
