using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands 
{
    public class CreateBnaSubjectNameCommand : IRequest<BaseCommandResponse> 
    {
        public CreateBnaSubjectNameDto BnaSubjectNameDto { get; set; }      
    }
}
   