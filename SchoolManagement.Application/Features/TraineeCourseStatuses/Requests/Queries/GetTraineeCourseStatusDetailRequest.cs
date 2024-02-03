using MediatR;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries
{
    public class GetTraineeCourseStatusesDetailRequest : IRequest<TraineeCourseStatusDto> 
    {
        public int Id { get; set; } 
    }
}
