using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands
{
    public class CreateBnaClassTestTypeCommand: IRequest<BaseCommandResponse>
    {
        public CreateBnaClassTestTypeDto BnaClassTestTypeDto { get; set; }
    }
}
