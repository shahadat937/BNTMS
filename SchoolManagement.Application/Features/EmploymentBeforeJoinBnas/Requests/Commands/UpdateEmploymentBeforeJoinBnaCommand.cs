using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using MediatR;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands
{
    public class UpdateEmploymentBeforeJoinBnaCommand : IRequest<Unit>
    {
        public EmploymentBeforeJoinBnaDto EmploymentBeforeJoinBnaDto { get; set; }

    }
}
