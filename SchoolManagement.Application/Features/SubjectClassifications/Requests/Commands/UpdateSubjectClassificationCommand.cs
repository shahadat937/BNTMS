using MediatR;
using SchoolManagement.Application.DTOs.SubjectClassifications;

namespace SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands
{
    public class UpdateSubjectClassificationCommand : IRequest<Unit> 
    {
        public SubjectClassificationDto SubjectClassificationDto { get; set; }

    }
}
