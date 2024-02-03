using SchoolManagement.Application.DTOs.Thana;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class UpdateThanaCommand : IRequest<Unit>
    {
        public ThanaDto ThanaDto { get; set; }

    }
}
