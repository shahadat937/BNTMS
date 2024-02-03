using MediatR;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands
{
    public class DeleteBnaSubjectNameCommand : IRequest  
    {   
        public int Id { get; set; }
    }
}
 