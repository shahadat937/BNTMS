using MediatR;
using SchoolManagement.Application.DTOs.MaritalStatus;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Commands
{
    public class UpdateMaritalStatusCommand : IRequest<Unit>
    {
        public MaritalStatusDto MaritalStatusDto { get; set; } 
    }
}
