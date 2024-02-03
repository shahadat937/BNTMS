using MediatR;
using SchoolManagement.Application.DTOs.JoiningReasons;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Commands
{
    public class UpdateJoiningReasonCommand : IRequest<Unit>  
    { 
        public JoiningReasonDto JoiningReasonDto { get; set; }     
    }
}
