using SchoolManagement.Application.DTOs.TraineePicture;
using MediatR;

namespace SchoolManagement.Application.Features.TraineePictures.Requests.Commands
{
    public class UpdateTraineePictureCommand : IRequest<Unit>
    {
        public TraineePictureDto TraineePictureDto { get; set; }

    }
}
