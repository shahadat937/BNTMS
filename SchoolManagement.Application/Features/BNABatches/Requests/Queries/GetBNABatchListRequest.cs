using MediatR;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaBatches.Requests.Queries
{
    public class GetBnaBatchListRequest : IRequest<PagedResult<BnaBatchDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
