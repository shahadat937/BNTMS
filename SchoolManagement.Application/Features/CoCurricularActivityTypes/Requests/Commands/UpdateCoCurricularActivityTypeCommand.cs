using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands
{
    public class UpdateCoCurricularActivityTypeCommand : IRequest<Unit>
    {
        public CoCurricularActivityTypeDto CoCurricularActivityTypeDto { get; set; } 

    }
}
