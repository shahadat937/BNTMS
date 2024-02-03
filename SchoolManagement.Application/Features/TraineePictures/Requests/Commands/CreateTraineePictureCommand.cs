using SchoolManagement.Application.DTOs.TraineePicture;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.TraineePictures.Requests.Commands
{
    public class CreateTraineePictureCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineePictureDto TraineePictureDto { get; set; }

    }
}
