using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Languages.Requests.Queries
{
    public class GetLanguageListRequest : IRequest<PagedResult<LanguageDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
