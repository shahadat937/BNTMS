using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries 
{ 
    public class GetBnaSemesterDurationListRequest : IRequest<PagedResult<BnaSemesterDurationDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
 