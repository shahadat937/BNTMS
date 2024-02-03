using SchoolManagement.Application.DTOs.GrandFatherType;
using MediatR;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands
{
    public class UpdateGrandFatherTypeCommand : IRequest<Unit>
    {
        public GrandFatherTypeDto GrandFatherTypeDto { get; set; }

    }
}
