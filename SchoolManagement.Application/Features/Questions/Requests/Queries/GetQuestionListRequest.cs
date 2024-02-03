using SchoolManagement.Application.DTOs.Question;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionListRequest : IRequest<PagedResult<QuestionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
