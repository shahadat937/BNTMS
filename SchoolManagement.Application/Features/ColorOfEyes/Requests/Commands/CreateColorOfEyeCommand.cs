using MediatR;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands
{
    public class CreateColorOfEyeCommand : IRequest<BaseCommandResponse>
    {
        public CreateColorOfEyeDto ColorOfEyeDto { get; set; }
    }
}
