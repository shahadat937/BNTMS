using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands
{
    public class DeleteTraineeBioDataOtherCommand : IRequest
    {
        public int TraineeBioDataOtherId { get; set; }
    }
}
