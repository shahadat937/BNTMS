using MediatR;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Commands
{
    public class CreateMaritalStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaritalStatusDto MaritalStatusDto { get; set; } 

    }
}
