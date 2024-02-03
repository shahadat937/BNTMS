using MediatR;
using SchoolManagement.Application.DTOs.DefenseType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Queries
{
    public class GetDefenseTypeDetailRequest : IRequest<DefenseTypeDto>
    {
        public int DefenseTypeId { get; set; }
    }
}
