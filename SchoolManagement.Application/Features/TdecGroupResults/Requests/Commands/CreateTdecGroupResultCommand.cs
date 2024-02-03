using MediatR;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands
{
    public class CreateTdecGroupResultCommand : IRequest<BaseCommandResponse>
    { 
        public CreateTdecGroupResultDto TdecGroupResultDto { get; set; }
    }
}
