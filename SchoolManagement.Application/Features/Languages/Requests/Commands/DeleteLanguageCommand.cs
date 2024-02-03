using MediatR;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class DeleteLanguageCommand : IRequest 
    {  
        public int Id { get; set; }
    }
}
