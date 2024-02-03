using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
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


namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Handlers.Queries
{
    public class GetForeignCourseGOInfoListRequestHandler : IRequestHandler<GetForeignCourseGOInfoListRequest, PagedResult<ForeignCourseGOInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseGOInfo> _ForeignCourseGOInfoRepository;

        private readonly IMapper _mapper;

        public GetForeignCourseGOInfoListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseGOInfo> ForeignCourseGOInfoRepository, IMapper mapper)
        {
            _ForeignCourseGOInfoRepository = ForeignCourseGOInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForeignCourseGOInfoDto>> Handle(GetForeignCourseGOInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForeignCourseGOInfo> UTOfficerCategories = _ForeignCourseGOInfoRepository.FilterWithInclude(x => (x.DocumentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseDuration.CourseName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ForeignCourseGOInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForeignCourseGOInfoDtos = _mapper.Map<List<ForeignCourseGOInfoDto>>(UTOfficerCategories);
            var result = new PagedResult<ForeignCourseGOInfoDto>(ForeignCourseGOInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
