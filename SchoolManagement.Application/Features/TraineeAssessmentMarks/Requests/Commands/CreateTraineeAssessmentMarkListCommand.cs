using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands
{
    public class CreateTraineeAssessmentMarkListCommand : IRequest<BaseCommandResponse>
    {
         public TraineeAssessmentMarkListDto TraineeAssessmentMarkListDto { get; set; }
    }
} 
 