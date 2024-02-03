using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands
{
    public class CreateCoCurricularActivityCommand : IRequest<BaseCommandResponse>
    {
        public CreateCoCurricularActivityDto CoCurricularActivityDto { get; set; }

    }
}
