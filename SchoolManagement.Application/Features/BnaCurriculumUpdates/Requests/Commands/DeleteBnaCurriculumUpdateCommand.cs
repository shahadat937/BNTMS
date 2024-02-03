using MediatR;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands
{
    public class DeleteBnaCurriculumUpdateCommand : IRequest
    {
        public int BnaCurriculumUpdateId { get; set; }
    }
}
