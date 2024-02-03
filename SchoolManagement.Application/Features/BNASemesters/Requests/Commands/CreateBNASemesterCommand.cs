using MediatR;
using SchoolManagement.Application.DTOs.BnaSemester;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Commands
{
    public class CreateBnaSemesterCommand: IRequest<BaseCommandResponse>
    {
        public CreateBnaSemesterDto BnaSemesterDto { get; set; }
    }
}
