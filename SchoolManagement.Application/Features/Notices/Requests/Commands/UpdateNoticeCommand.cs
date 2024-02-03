using MediatR;
using SchoolManagement.Application.DTOs.Notice;

namespace SchoolManagement.Application.Features.Notices.Requests.Commands
{
    public class UpdateNoticeCommand : IRequest<Unit>
    {
        public NoticeDto NoticeDto { get; set; }
    }
} 
