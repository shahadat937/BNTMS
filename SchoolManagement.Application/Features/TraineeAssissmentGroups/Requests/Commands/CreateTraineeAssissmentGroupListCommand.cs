using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands
{
    public class CreateTraineeAssissmentGroupListCommand : IRequest<BaseCommandResponse>
    {
         public TraineeAssessmentGroupListDto TraineeAssissmentGroupListDto { get; set; }
    }
} 
 