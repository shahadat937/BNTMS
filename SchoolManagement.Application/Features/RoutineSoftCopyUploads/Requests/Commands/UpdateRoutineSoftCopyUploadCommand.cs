using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using MediatR;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands
{
    public class UpdateRoutineSoftCopyUploadCommand : IRequest<Unit>
    {
        public CreateRoutineSoftCopyUploadDto CreateRoutineSoftCopyUploadDto { get; set; }

    }
}
