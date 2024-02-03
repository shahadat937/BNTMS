using MediatR;

namespace SchoolManagement.Application.Features.FamilyNominations.Requests.Commands
{
    public class DeleteFamilyNominationCommand : IRequest   
    {  
        public int Id { get; set; }
    }
}
