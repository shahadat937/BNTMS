using MediatR;
using SchoolManagement.Application.DTOs.MarkType;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Commands
{
    public class UpdateMarkTypeCommand : IRequest<Unit>
    {
        public MarkTypeDto MarkTypeDto { get; set; } 
    }
}
