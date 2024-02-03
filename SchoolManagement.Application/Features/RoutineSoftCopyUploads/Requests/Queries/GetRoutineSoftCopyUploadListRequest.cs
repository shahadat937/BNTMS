using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Queries
{
    public class GetRoutineSoftCopyUploadListRequest : IRequest<PagedResult<RoutineSoftCopyUploadDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
 