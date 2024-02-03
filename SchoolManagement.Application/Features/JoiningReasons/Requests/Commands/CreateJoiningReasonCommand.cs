using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.JoiningReasons;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Commands
{
    public class CreateJoiningReasonCommand : IRequest<BaseCommandResponse> 
    {
        public CreateJoiningReasonDto JoiningReasonDto { get; set; }      

    }
}
