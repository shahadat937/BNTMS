using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Queries
{
    public class GetNationalityListRequest : IRequest<PagedResult<NationalityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
