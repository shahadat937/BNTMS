using MediatR;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Notices.Requests.Queries
{
    public class GetNoticeListRequest : IRequest<PagedResult<NoticeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
