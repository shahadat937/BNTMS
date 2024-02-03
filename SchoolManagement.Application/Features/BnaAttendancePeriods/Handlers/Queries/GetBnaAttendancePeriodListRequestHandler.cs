using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Queries
{
    public class GetBnaAttendancePeriodListRequestHandler : IRequestHandler<GetBnaAttendancePeriodListRequest, PagedResult<BnaAttendancePeriodDto>>
    {

        private readonly ISchoolManagementRepository<BnaAttendancePeriod> _BnaAttendancePeriodRepository;

        private readonly IMapper _mapper;

        public GetBnaAttendancePeriodListRequestHandler(ISchoolManagementRepository<BnaAttendancePeriod> BnaAttendancePeriodRepository, IMapper mapper)
        {
            _BnaAttendancePeriodRepository = BnaAttendancePeriodRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaAttendancePeriodDto>> Handle(GetBnaAttendancePeriodListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaAttendancePeriod> UTOfficerCategories = _BnaAttendancePeriodRepository.FilterWithInclude(x => (x.PeriodName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.BnaAttendancePeriodId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaAttendancePeriodDtos = _mapper.Map<List<BnaAttendancePeriodDto>>(UTOfficerCategories);
            var result = new PagedResult<BnaAttendancePeriodDto>(BnaAttendancePeriodDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
