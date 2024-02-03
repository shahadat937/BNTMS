using MediatR;
using SchoolManagement.Application.DTOs.HairColor;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Commands
{
    public class CreateHairColorCommand : IRequest<BaseCommandResponse>
    {
        public CreateHairColorDto HairColorDto { get; set; }
    }
}
