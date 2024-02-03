using MediatR;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands
{
    public class UpdateBnaSemesterDurationCommand : IRequest<Unit>   
    { 
        public BnaSemesterDurationDto BnaSemesterDurationDto { get; set; }     
    }
}
  