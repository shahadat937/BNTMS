using MediatR;
using SchoolManagement.Application.DTOs.BaseNames;

namespace SchoolManagement.Application.Features.BaseNames.Requests.Commands
{
    public class UpdateBaseNameCommand : IRequest<Unit>   
    { 
        public BaseNameDto BaseNameDto { get; set; }     
    }
}
