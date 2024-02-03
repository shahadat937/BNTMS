using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands 
{
    public class CreateBnaSemesterDurationCommand : IRequest<BaseCommandResponse> 
    {
        public CreateBnaSemesterDurationDto BnaSemesterDurationDto { get; set; }      
    }
}
   