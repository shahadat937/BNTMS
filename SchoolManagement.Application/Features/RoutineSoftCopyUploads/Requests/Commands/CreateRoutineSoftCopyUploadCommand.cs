using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands
{
    public class CreateRoutineSoftCopyUploadCommand : IRequest<BaseCommandResponse>
    {
        public CreateRoutineSoftCopyUploadDto RoutineSoftCopyUploadDto { get; set; }

    }
}
