using SchoolManagement.Application.DTOs.Question;
using MediatR;

namespace SchoolManagement.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionDetailRequest : IRequest<QuestionDto>
    {
        public int QuestionId { get; set; }
    }
}
