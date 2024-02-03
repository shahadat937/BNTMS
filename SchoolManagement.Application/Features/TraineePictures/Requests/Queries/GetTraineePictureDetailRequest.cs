using SchoolManagement.Application.DTOs.TraineePicture;
using MediatR;

namespace SchoolManagement.Application.Features.TraineePictures.Requests.Queries
{
    public class GetTraineePictureDetailRequest : IRequest<TraineePictureDto>
    {
        public int TraineePictureId { get; set; }
    }
}
