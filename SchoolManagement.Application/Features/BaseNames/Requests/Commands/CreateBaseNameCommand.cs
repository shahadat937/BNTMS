using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.BaseNames;

namespace SchoolManagement.Application.Features.BaseNames.Requests.Commands 
{
    public class CreateBaseNameCommand : IRequest<BaseCommandResponse> 
    {
        public CreateBaseNameDto BaseNameDto { get; set; }      
    }
}
 