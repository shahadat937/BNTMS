using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notices.Handlers.Queries
{
    public class GetNoticeDetailRequestHandler : IRequestHandler<GetNoticeDetailRequest, NoticeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Notice> _NoticeRepository;
        public GetNoticeDetailRequestHandler(ISchoolManagementRepository<Notice> NoticeRepository, IMapper mapper)
        {
            _NoticeRepository = NoticeRepository;
            _mapper = mapper;
        }
        public async Task<NoticeDto> Handle(GetNoticeDetailRequest request, CancellationToken cancellationToken)
        {
            var Notice = await _NoticeRepository.Get(request.NoticeId);
            return _mapper.Map<NoticeDto>(Notice);
        }
    }
}
