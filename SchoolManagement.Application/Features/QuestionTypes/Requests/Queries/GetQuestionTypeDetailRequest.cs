using MediatR;
using SchoolManagement.Application.DTOs.QuestionType;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Queries
{
    public class GetQuestionTypeDetailRequest : IRequest<QuestionTypeDto>
    {
        public int QuestionTypeId { get; set; }
    }
}
