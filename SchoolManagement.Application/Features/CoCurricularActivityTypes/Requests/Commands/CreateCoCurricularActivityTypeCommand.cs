using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands
{
    public class CreateCoCurricularActivityTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateCoCurricularActivityTypeDto CoCurricularActivityTypeDto { get; set; }

    }
}
