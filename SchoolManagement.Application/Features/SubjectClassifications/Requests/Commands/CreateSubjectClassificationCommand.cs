using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.SubjectClassifications;

namespace SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands
{
    public class CreateSubjectClassificationCommand : IRequest<BaseCommandResponse>
    {
        public CreateSubjectClassificationDto SubjectClassificationDto { get; set; }

    }
}
