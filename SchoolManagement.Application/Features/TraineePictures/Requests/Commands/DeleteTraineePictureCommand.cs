using MediatR;

namespace SchoolManagement.Application.Features.TraineePictures.Requests.Commands
{
    public class DeleteTraineePictureCommand : IRequest
    {
        public int TraineePictureId { get; set; }
    }
}
