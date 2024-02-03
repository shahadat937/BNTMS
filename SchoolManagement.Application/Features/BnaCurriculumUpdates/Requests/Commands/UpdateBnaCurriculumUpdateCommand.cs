using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using MediatR;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands
{
    public class UpdateBnaCurriculumUpdateCommand : IRequest<Unit>
    {
        public BnaCurriculumUpdateDto BnaCurriculumUpdateDto { get; set; }

    }
}
