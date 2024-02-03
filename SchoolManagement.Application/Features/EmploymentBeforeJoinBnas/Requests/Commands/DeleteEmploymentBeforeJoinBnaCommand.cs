using MediatR;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands
{
    public class DeleteEmploymentBeforeJoinBnaCommand : IRequest
    {
        public int EmploymentBeforeJoinBnaId { get; set; }
    }
}
