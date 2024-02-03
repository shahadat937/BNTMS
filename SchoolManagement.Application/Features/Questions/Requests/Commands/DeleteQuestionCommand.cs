using MediatR;

namespace SchoolManagement.Application.Features.Questions.Requests.Commands
{
    public class DeleteQuestionCommand : IRequest
    {
        public int QuestionId { get; set; }
    }
}
