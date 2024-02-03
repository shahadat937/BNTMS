using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CoCurricularActivity;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands
{
    public class UpdateElectionCommand : IRequest<Unit>
    {
        public CoCurricularActivityDto CoCurricularActivityDto { get; set; } 

    }
}
