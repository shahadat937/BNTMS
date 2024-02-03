using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTest;

namespace SchoolManagement.Application.Features.BnaClassTests.Requests.Commands
{
    public class UpdateBnaClassTestCommand: IRequest<Unit>
    {
        public BnaClassTestDto BnaClassTestDto { get; set; }
    }
}
 