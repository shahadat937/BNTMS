using MediatR;

namespace SchoolManagement.Application.Features.Notices.Requests.Commands
{
    public class DeleteNoticeCommand : IRequest
    {
        public int NoticeId { get; set; }
    }
}
 