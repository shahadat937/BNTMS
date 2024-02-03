using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Commands
{
    public class UpdateSubjectMarkCommand : IRequest<Unit>
    {
        public SubjectMarkDto SubjectMarkDto { get; set; } 
    }
}
