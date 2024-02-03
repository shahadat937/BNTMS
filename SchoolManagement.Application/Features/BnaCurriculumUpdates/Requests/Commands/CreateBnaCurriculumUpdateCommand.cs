using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands
{
    public class CreateBnaCurriculumUpdateCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaCurriculumUpdateDto BnaCurriculumUpdateDto { get; set; }

    }
}
