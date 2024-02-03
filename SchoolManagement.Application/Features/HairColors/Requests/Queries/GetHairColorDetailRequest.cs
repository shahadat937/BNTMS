using MediatR;
using SchoolManagement.Application.DTOs.HairColor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Queries
{
    public class GetHairColorDetailRequest : IRequest<HairColorDto>
    {
        public int HairColorId { get; set; }
    }
}
