using MediatR;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands
{
    public class DeleteGrandFatherTypeCommand : IRequest
    {
        public int GrandfatherTypeId { get; set; }
    }
}
