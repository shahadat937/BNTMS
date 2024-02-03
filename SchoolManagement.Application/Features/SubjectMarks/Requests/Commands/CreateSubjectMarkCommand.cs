using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Commands
{
    public class CreateSubjectMarkCommand : IRequest<BaseCommandResponse>
    {
        public CreateSubjectMarkDto SubjectMarkDto { get; set; } 

    }
}
