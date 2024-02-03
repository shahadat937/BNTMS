using MediatR;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands
{
    public class UpdateBnaCurriculamTypeCommand : IRequest<Unit>
    {
        public BnaCurriculamTypeDto BnaCurriculamTypeDto { get; set; }
    }
}
 