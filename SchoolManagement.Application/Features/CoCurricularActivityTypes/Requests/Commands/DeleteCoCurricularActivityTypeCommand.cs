using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands
{
    public class DeleteCoCurricularActivityTypeCommand : IRequest
    {
        public int CoCurricularActivityTypeId { get; set; }
    }
}
