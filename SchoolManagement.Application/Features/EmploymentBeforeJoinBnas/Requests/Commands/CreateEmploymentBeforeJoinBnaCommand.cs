using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands
{
    public class CreateEmploymentBeforeJoinBnaCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmploymentBeforeJoinBnaDto EmploymentBeforeJoinBnaDto { get; set; }

    }
}
