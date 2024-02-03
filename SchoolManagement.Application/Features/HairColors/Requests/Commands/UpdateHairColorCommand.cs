using MediatR;
using SchoolManagement.Application.DTOs.HairColor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Commands
{
    public class UpdateHairColorCommand : IRequest<Unit>
    {
        public HairColorDto HairColorDto { get; set; }
    }
}
