using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Queries;
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

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Handlers.Queries
{
    public class GetSwimmingDrivingLevelListRequestHandler : IRequestHandler<GetSwimmingDrivingLevelListRequest, PagedResult<SwimmingDrivingLevelDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDrivingLevel> _SwimmingDrivingLevelRepository;

        private readonly IMapper _mapper;

        public GetSwimmingDrivingLevelListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDrivingLevel> SwimmingDrivingLevelRepository, IMapper mapper)
        {
            _SwimmingDrivingLevelRepository = SwimmingDrivingLevelRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SwimmingDrivingLevelDto>> Handle(GetSwimmingDrivingLevelListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.SwimmingDrivingLevel> SwimmingDrivingLevels = _SwimmingDrivingLevelRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = SwimmingDrivingLevels.Count();
            SwimmingDrivingLevels = SwimmingDrivingLevels.OrderByDescending(x => x.SwimmingDrivingLevelId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SwimmingDrivingLevelDtos = _mapper.Map<List<SwimmingDrivingLevelDto>>(SwimmingDrivingLevels);
            var result = new PagedResult<SwimmingDrivingLevelDto>(SwimmingDrivingLevelDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
