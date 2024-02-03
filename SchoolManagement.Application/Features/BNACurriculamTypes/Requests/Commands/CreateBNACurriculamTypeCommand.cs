using MediatR;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands
{
    public class CreateBnaCurriculamTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaCurriculamTypeDto BnaCurriculamTypeDto { get; set; }
    }
}
 