using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Questions.Requests.Commands
{
    public class CreateQuestionCommand : IRequest<BaseCommandResponse>
    {
        public CreateQuestionDto QuestionDto { get; set; }

    }
}
