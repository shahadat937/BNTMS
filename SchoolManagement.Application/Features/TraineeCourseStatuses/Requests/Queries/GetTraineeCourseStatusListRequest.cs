using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries
{
    public class GetTraineeCourseStatusesListRequest : IRequest<PagedResult<TraineeCourseStatusDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
