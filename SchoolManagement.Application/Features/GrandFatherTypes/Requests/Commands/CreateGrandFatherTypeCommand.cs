using SchoolManagement.Application.DTOs.GrandFatherType;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands
{
    public class CreateGrandFatherTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateGrandFatherTypeDto GrandFatherTypeDto { get; set; }

    }
}
