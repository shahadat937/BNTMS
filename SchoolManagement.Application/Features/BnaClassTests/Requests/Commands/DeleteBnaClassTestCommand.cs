using MediatR;

namespace SchoolManagement.Application.Features.BnaClassTests.Requests.Commands
{
    public class DeleteBnaClassTestCommand: IRequest
    {
        public int BnaClassTestId { get; set; }
    }
}
 