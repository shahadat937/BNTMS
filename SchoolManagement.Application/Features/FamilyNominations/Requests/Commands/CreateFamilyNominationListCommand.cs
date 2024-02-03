using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.FamilyNomination;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Commands
{
    public class CreateFamilyNominationListCommand : IRequest<BaseCommandResponse>
    {
         public FamilyNominationListDto FamilyNominationListDto { get; set; }
    }
} 
 