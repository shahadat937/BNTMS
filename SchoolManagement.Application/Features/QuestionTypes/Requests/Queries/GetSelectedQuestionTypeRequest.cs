using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.QuestionTypes.Requests.Queries
{
    public class GetSelectedQuestionTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
