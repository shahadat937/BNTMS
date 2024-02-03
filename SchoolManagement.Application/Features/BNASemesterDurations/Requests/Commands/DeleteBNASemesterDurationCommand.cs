using MediatR;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands
{
    public class DeleteBnaSemesterDurationCommand : IRequest  
    {   
        public int Id { get; set; }
    }
}
  