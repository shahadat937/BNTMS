using MediatR;
using SchoolManagement.Application.DTOs.SubjectTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Commands
{
    public class CreateSubjectTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateSubjectTypeDto SubjectTypeDto { get; set; }
    }
}
