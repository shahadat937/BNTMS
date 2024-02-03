using MediatR;
using SchoolManagement.Application.DTOs.SubjectTypes;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Commands
{
    public class UpdateSubjectTypeCommand : IRequest<Unit>
    {
        public SubjectTypeDto SubjectTypeDto { get; set; }
    }
}
