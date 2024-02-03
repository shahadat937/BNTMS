using MediatR;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Commands
{
    public class DeleteIndividualNoticeCommand : IRequest
    {
        public int IndividualNoticeId { get; set; }
    }
}
 