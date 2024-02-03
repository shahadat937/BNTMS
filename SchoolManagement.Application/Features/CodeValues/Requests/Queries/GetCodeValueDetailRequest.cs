using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.CodeValues.Requests.Queries
{
    public class GetCodeValueDetailRequest : IRequest<CodeValueDto>  
    {
        public int Id { get; set; } 
    }
}
