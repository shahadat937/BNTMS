using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Commands
{
    public class CreateGrandFatherCommand : IRequest<BaseCommandResponse>
    {
        public CreateGrandFatherDto GrandFatherDto { get; set; }

    }
}
