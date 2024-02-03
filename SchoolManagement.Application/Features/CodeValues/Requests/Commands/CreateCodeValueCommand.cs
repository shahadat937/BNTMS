using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.CodeValues.Requests.Commands 
{
    public class CreateCodeValueCommand : IRequest<BaseCommandResponse> 
    {
        public CreateCodeValueDto CodeValueDto { get; set; }      

    }
}
