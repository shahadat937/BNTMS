using MediatR;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands
{
    public class DeleteBnaClassTestTypeCommand: IRequest
    {
        public int BnaClassTestTypeId { get; set; }
    }
}
 