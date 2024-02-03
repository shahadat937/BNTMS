using MediatR;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Queries
{
    public class GetIndividualNoticeListRequest : IRequest<PagedResult<IndividualNoticeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
