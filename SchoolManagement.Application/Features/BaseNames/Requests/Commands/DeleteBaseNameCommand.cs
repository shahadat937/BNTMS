using MediatR;

namespace SchoolManagement.Application.Features.BaseNames.Requests.Commands
{
    public class DeleteBaseNameCommand : IRequest  
    {   
        public int Id { get; set; }
    }
}
