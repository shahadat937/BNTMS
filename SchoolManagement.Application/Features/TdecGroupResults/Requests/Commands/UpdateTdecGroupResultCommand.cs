using MediatR;
using SchoolManagement.Application.DTOs.TdecGroupResult;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands
{
    public class UpdateTdecGroupResultCommand : IRequest<Unit>
    {
        public TdecGroupResultDto TdecGroupResultDto { get; set; }
    }
}
