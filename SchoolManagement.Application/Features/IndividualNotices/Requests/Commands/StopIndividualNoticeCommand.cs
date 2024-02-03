using MediatR;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Commands
{
    public class StopIndividualNoticeCommand : IRequest
    {
        public int IndividualNoticeId { get; set; }  
    }
}
