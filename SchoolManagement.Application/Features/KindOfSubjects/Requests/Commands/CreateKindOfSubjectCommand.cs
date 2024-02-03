using MediatR;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands 
{ 
    public class CreateKindOfSubjectCommand : IRequest<BaseCommandResponse> 
    {
        public CreateKindOfSubjectDto KindOfSubjectDto { get; set; }      

    }
}
