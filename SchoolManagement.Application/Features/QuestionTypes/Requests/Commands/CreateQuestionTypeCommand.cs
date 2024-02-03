using MediatR;
using SchoolManagement.Application.DTOs.QuestionType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Commands
{
    public class CreateQuestionTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateQuestionTypeDto QuestionTypeDto { get; set; }
    }
}
