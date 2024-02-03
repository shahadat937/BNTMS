using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Queries
{
    public class GetIndividualNoticeListRequestHandler : IRequestHandler<GetIndividualNoticeListRequest, PagedResult<IndividualNoticeDto>>
    {

        private readonly ISchoolManagementRepository<IndividualNotice> _IndividualNoticeRepository;

        private readonly IMapper _mapper;

        public GetIndividualNoticeListRequestHandler(ISchoolManagementRepository<IndividualNotice> IndividualNoticeRepository, IMapper mapper)
        {
            _IndividualNoticeRepository = IndividualNoticeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<IndividualNoticeDto>> Handle(GetIndividualNoticeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<IndividualNotice> IndividualNoticees = _IndividualNoticeRepository.FilterWithInclude(x => (x.NoticeDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = IndividualNoticees.Count();
            IndividualNoticees = IndividualNoticees.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var IndividualNoticeDtos = _mapper.Map<List<IndividualNoticeDto>>(IndividualNoticees);
            var result = new PagedResult<IndividualNoticeDto>(IndividualNoticeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
