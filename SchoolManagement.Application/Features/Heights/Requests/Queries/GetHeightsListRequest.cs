using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Heights.Requests.Queries
{
    public class GetHeightsListRequest : IRequest<PagedResult<HeightDto>>
    {
        public QueryParams QueryParams { get; set; } 
    }
}
