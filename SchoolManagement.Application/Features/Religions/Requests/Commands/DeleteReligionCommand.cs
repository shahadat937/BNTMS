using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Religions.Requests.Commands
{
    public class DeleteReligionCommand : IRequest
    {
        public int ReligionId { get; set; }
    }
}
