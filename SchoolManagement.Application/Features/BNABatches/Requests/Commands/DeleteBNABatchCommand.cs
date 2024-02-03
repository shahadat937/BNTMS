using MediatR;

namespace SchoolManagement.Application.Features.BnaBatches.Requests.Commands
{
    public class DeleteBnaBatchCommand : IRequest
    {
        public int BnaBatchId { get; set; }
    }
}
 