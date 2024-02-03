using AutoMapper;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notices.Handlers.Queries   
{
    public class GetSelectedNoticeBySchoolRequestHandler : IRequestHandler<GetSelectedNoticeBySchoolRequest, List<NoticeDto>>
    {

        private readonly ISchoolManagementRepository<Notice> _NoticeRepository;

        private readonly IMapper _mapper;

        public GetSelectedNoticeBySchoolRequestHandler(ISchoolManagementRepository<Notice> NoticeRepository, IMapper mapper)
        {
            _NoticeRepository = NoticeRepository;
            _mapper = mapper;
        }

        public async Task<List<NoticeDto>> Handle(GetSelectedNoticeBySchoolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Notice> Notices = _NoticeRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName", "CourseDuration").OrderBy(x => x.Status);

            var NoticeDtos = _mapper.Map<List<NoticeDto>>(Notices);

            return NoticeDtos;
        }
    }
}
