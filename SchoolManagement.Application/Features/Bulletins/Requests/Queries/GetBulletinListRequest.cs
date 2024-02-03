using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinListRequest : IRequest<PagedResult<BulletinDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int? BaseSchoolNameId { get; set; }
    }
}
