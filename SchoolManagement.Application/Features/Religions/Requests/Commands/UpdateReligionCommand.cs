using SchoolManagement.Application.DTOs.Religion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Religions.Requests.Commands
{
    public class UpdateReligionCommand : IRequest<Unit>
    {
        public ReligionDto ReligionDto { get; set; }

    }
}
