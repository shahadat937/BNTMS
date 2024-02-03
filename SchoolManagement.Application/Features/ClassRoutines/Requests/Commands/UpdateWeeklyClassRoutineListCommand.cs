using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Commands
{
    public class UpdateWeeklyClassRoutineListCommand : IRequest<BaseCommandResponse>
    {
         public UpdateClassRoutineDtoList UpdateClassRoutineDtoList { get; set; }
    }
} 
 