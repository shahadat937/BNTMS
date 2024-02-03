using SchoolManagement.Application.DTOs.SwimmingDriving;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries
{
    public class GetSwimmingDrivingListRequest : IRequest<PagedResult<SwimmingDrivingDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
