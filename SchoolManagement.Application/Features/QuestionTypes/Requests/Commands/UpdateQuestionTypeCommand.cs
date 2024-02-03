using MediatR;
using SchoolManagement.Application.DTOs.QuestionType;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Commands
{
    public class UpdateQuestionTypeCommand : IRequest<Unit>
    {
        public QuestionTypeDto QuestionTypeDto { get; set; }
    }
}
