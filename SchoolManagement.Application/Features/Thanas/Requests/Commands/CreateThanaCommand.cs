using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class CreateThanaCommand : IRequest<BaseCommandResponse>
    {
        public CreateThanaDto ThanaDto { get; set; }

    }
}
