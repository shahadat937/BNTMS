using MediatR;
using SchoolManagement.Application.DTOs.ClassType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassTypes.Requests.Queries
{
    public class GetClassTypeDetailRequest : IRequest<ClassTypeDto>
    {
        public int ClassTypeId { get; set; }
    }
}
