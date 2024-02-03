using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.CodeValueType;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.CodeValueTypes.Requests.Queries
{
    public class GetCodeValueTypeDetailRequest : IRequest<CodeValueTypeDto> 
    {
        public int Id { get; set; } 
    }
}
