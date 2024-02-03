using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using MediatR;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands
{
    public class UpdateTraineeBioDataOtherCommand : IRequest<Unit>
    {
        public TraineeBioDataOtherDto TraineeBioDataOtherDto { get; set; }

    }
}
