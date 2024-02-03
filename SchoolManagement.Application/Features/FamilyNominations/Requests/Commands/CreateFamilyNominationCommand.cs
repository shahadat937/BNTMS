using MediatR;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Commands
{
    public class CreateFamilyNominationCommand : IRequest<BaseCommandResponse> 
    {
        public CreateFamilyNominationDto FamilyNominationDto { get; set; }      

    }
}
