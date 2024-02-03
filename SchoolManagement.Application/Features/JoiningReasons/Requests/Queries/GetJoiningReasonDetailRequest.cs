using MediatR;
using SchoolManagement.Application.DTOs.JoiningReasons;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Queries
{
    public class GetJoiningReasonDetailRequest : IRequest<JoiningReasonDto> 
    {
        public int Id { get; set; } 
    }
}
