using MediatR;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Queries
{
    public class GetBnaCurriculamTypeDetailRequest : IRequest<BnaCurriculamTypeDto>
    {
        public int BnaCurriculamTypeId { get; set; }
    }
}
 