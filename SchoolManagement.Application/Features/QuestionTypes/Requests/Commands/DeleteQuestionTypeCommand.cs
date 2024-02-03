using MediatR;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Commands
{
    public class DeleteQuestionTypeCommand : IRequest
    {
        public int QuestionTypeId { get; set; }
    }
}
