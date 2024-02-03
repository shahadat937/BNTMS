using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Queries
{
    public class GetBnaCurriculumUpdateListRequest : IRequest<PagedResult<BnaCurriculumUpdateDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
