using MediatR;
using SchoolManagement.Application.DTOs.ColorOfEye;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries
{
    public class GetColorOfEyeDetailRequest : IRequest<ColorOfEyeDto>
    {
        public int ColorOfEyesId { get; set; }
    }
}
