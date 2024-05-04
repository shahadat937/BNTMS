using MediatR;
using SchoolManagement.Application.DTOs.BnaClassRoutines;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassRoutine.Requests.Commands
{
    public class CreateBnaClassRoutineCommand : IRequest<BaseCommandResponse>
    {
        public BnaClassRoutineListDto BnaClassRoutineDto { get; set; }
    }
}
