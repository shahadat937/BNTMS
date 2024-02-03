using MediatR;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Queries
{
    public class GetFamilyNominationListRequest : IRequest<PagedResult<FamilyNominationDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
