using MediatR;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Commands
{
    public class DeleteMaritalStatusCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
