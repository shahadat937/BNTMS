using MediatR;
using SchoolManagement.Application.DTOs.ErrorLog;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ErrorLogs.Requests.Queries
{
    public class GetErrorLogListRequest : IRequest<PagedResult<ErrorLogDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
