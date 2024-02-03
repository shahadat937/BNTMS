using MediatR;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Application.Responses;


namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands
{
    public class CreateExamPeriodTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamPeriodTypeDto ExamPeriodTypeDto { get; set; }
    }
}
