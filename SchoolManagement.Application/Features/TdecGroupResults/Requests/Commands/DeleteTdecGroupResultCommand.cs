using MediatR;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands
{
    public class DeleteTdecGroupResultCommand : IRequest
    {
        public int TdecGroupResultId { get; set; }
    }
}
