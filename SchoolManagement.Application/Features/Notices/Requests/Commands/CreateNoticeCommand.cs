using MediatR;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Notices.Requests.Commands
{
    public class CreateNoticeCommand : IRequest<BaseCommandResponse>
    {
        public CreateNoticeDto NoticeDto { get; set; }
    }
}
