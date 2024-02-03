using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands
{
    public class CreateInterServiceMarkListCommand : IRequest<BaseCommandResponse>
    {
         public InterServiceMarkListDto InterServiceMarkListDto { get; set; }
    }
} 
 