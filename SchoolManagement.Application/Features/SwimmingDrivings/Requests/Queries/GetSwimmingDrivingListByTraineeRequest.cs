using MediatR;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries
{
    public class GetSwimmingDrivingListByTraineeRequest : IRequest<List<SwimmingDrivingDto>>
    {
        public int TraineeId { get; set; } 
    }
    
}
