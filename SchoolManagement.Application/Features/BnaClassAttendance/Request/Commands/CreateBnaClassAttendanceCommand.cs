using MediatR;
using SchoolManagement.Application.DTOs.BnaClassAttrendance;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Request.Commands
{
    public class CreateBnaClassAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaClassAttendanceDto BnaClassAttendanceDto { get; set; }

    }
}
