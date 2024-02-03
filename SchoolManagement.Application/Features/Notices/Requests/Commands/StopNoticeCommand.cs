using MediatR;

namespace SchoolManagement.Application.Features.Notices.Requests.Commands
{
    public class StopNoticeCommand : IRequest
    {
        public int NoticeId { get; set; }  
    }
}
