using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaClassTests.Requests.Commands
{
    public class CreateBnaClassTestCommand: IRequest<BaseCommandResponse>
    {
        public CreateBnaClassTestDto BnaClassTestDto { get; set; }
    }
}
