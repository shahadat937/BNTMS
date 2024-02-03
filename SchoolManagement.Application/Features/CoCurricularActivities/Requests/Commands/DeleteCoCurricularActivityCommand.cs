using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands
{
    public class DeleteCoCurricularActivityCommand : IRequest
    {
        public int CoCurricularActivityId { get; set; }
    }
}
