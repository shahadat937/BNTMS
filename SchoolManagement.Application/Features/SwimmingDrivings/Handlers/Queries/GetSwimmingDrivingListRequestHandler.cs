using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries;
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

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Queries
{
    public class GetSwimmingDrivingListRequestHandler : IRequestHandler<GetSwimmingDrivingListRequest, PagedResult<SwimmingDrivingDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> _SwimmingDrivingRepository;

        private readonly IMapper _mapper;

        public GetSwimmingDrivingListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> SwimmingDrivingRepository, IMapper mapper)
        {
            _SwimmingDrivingRepository = SwimmingDrivingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SwimmingDrivingDto>> Handle(GetSwimmingDrivingListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.SwimmingDriving> SwimmingDrivings = _SwimmingDrivingRepository.FilterWithInclude(x => (x.AdditionalInformation.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SwimmingDrivings.Count();
            SwimmingDrivings = SwimmingDrivings.OrderByDescending(x => x.SwimmingDrivingId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SwimmingDrivingDtos = _mapper.Map<List<SwimmingDrivingDto>>(SwimmingDrivings);
            var result = new PagedResult<SwimmingDrivingDto>(SwimmingDrivingDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
