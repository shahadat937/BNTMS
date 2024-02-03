using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notices.Handlers.Queries
{
    public class GetNoticeListRequestHandler : IRequestHandler<GetNoticeListRequest, PagedResult<NoticeDto>>
    {

        private readonly ISchoolManagementRepository<Notice> _NoticeRepository;

        private readonly IMapper _mapper;

        public GetNoticeListRequestHandler(ISchoolManagementRepository<Notice> NoticeRepository, IMapper mapper)
        {
            _NoticeRepository = NoticeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NoticeDto>> Handle(GetNoticeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Notice> Noticees = _NoticeRepository.FilterWithInclude(x => (x.NoticeDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Noticees.Count();
            Noticees = Noticees.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NoticeDtos = _mapper.Map<List<NoticeDto>>(Noticees);
            var result = new PagedResult<NoticeDto>(NoticeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
