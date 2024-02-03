using SchoolManagement.Application.DTOs.TraineePicture;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineePictures.Requests.Queries
{
    public class GetTraineePictureListRequest : IRequest<PagedResult<TraineePictureDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
