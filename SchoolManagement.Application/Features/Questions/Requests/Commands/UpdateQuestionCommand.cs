using SchoolManagement.Application.DTOs.Question;
using MediatR;

namespace SchoolManagement.Application.Features.Questions.Requests.Commands
{
    public class UpdateQuestionCommand : IRequest<Unit>
    {
        public QuestionDto QuestionDto { get; set; }

    }
}
