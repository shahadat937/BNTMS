using MediatR;
using SchoolManagement.Application.DTOs.AllowancePercentage;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands
{
    public class UpdateAllowancePercentageCommand : IRequest<Unit>
    {
        public AllowancePercentageDto AllowancePercentageDto { get; set; }
    }
}
 