using MediatR;
using SchoolManagement.Application.DTOs.Question;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionListByTraineeRequest : IRequest<List<QuestionDto>>
    {
        public int Traineeid { get; set; }
    }
    
}
