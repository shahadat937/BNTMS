using MediatR;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaBatches.Requests.Commands
{
    public class CreateBnaBatchCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaBatchDto BnaBatchDto { get; set; }
    }
}
 