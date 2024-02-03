using MediatR;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands
{
    public class DeleteRoutineSoftCopyUploadCommand : IRequest
    {
        public int RoutineSoftCopyUploadId { get; set; }
    }
}
