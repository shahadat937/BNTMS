using MediatR;
using SchoolManagement.Application.DTOs.QuestionType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Queries
{
    public class GetQuestionTypeListRequest : IRequest<PagedResult<QuestionTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
