using MediatR;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries
{
    public class GetIndividualBulletinListRequest : IRequest<PagedResult<IndividualBulletinDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
