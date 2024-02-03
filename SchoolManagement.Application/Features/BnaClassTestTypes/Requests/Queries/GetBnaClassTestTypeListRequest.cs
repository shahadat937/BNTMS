using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries
{
    public class GetBnaClassTestTypeListRequest: IRequest<PagedResult<BnaClassTestTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
