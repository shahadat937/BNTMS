using MediatR;
using SchoolManagement.Application.DTOs.FamilyNomination;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Queries
{
    public class GetFamilyNominationDetailRequest : IRequest<FamilyNominationDto> 
    {
        public int Id { get; set; } 
    }
}
