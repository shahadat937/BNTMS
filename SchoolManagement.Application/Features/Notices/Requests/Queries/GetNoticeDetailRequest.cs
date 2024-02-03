using MediatR;
using SchoolManagement.Application.DTOs.Notice;

namespace SchoolManagement.Application.Features.Notices.Requests.Queries
{
    public class GetNoticeDetailRequest : IRequest<NoticeDto>
    {
        public int NoticeId { get; set; }
    }
}
 