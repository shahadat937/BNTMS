using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Commands
{
    public class DeleteBnaSemesterCommand: IRequest
    {
        public int BnaSemesterId { get; set; }
    }
}
 