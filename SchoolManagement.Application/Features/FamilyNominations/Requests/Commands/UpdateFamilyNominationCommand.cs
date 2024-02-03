using MediatR;
using SchoolManagement.Application.DTOs.FamilyNomination;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Commands
{
    public class UpdateFamilyNominationCommand : IRequest<Unit>  
    { 
        public FamilyNominationDto FamilyNominationDto { get; set; }     
    }
}
