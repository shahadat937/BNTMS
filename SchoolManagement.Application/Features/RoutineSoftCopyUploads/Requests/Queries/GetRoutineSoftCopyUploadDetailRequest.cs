using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using MediatR;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Queries
{
    public class GetRoutineSoftCopyUploadDetailRequest : IRequest<RoutineSoftCopyUploadDto>
    {
        public int RoutineSoftCopyUploadId { get; set; }
    }
}
