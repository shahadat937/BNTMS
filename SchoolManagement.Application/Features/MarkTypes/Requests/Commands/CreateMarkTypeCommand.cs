using MediatR;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Commands
{
    public class CreateMarkTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateMarkTypeDto MarkTypeDto { get; set; } 

    }
}
