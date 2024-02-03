using MediatR;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands
{
    public class CreateAllowancePercentageCommand : IRequest<BaseCommandResponse>
    {
        public CreateAllowancePercentageDto AllowancePercentageDto { get; set; }
    }
}
 