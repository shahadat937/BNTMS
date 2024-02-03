using MediatR;
using SchoolManagement.Application.DTOs.ColorOfEye;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands
{
    public class UpdateColorOfEyeCommand : IRequest<Unit>
    {
        public ColorOfEyeDto ColorOfEyeDto { get; set; }
    }
}
