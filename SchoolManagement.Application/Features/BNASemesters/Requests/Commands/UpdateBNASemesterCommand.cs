using MediatR;
using SchoolManagement.Application.DTOs.BnaSemester;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Commands
{
    public class UpdateBnaSemesterCommand: IRequest<Unit>
    {
        public BnaSemesterDto BnaSemesterDto { get; set; }
    }
}
 