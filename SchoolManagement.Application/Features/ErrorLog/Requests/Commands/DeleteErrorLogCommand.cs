using MediatR;

namespace SchoolManagement.Application.Features.ErrorLogs.Requests.Commands
{
    public class DeleteErrorLogCommand : IRequest
    {
        public int ErrorLogId { get; set; }
    }
}
