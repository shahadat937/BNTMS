using SchoolManagement.Application.DTOs.SwimmingDriving;
using MediatR;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries
{
    public class GetSwimmingDrivingDetailRequest : IRequest<SwimmingDrivingDto>
    {
        public int SwimmingDrivingId { get; set; }
    }
}
