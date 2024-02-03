using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Electeds;

namespace SchoolManagement.Application.Features.Electeds.Requests.Commands 
{
    public class CreateElectedCommand : IRequest<BaseCommandResponse> 
    {
        public CreateElectedDto ElectedDto { get; set; }      

    }
}
