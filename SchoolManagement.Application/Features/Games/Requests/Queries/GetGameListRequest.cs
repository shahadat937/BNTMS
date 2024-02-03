using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Games;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Games.Requests.Queries
{
    public class GetGameListRequest : IRequest<PagedResult<GameDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
