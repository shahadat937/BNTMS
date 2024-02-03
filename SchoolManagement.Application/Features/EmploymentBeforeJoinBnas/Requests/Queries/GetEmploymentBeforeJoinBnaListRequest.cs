using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries
{
    public class GetEmploymentBeforeJoinBnaListRequest : IRequest<PagedResult<EmploymentBeforeJoinBnaDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
