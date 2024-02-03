using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Heights.Requests.Commands 
{
    public class CreateHeightsCommand : IRequest<BaseCommandResponse> 
    {
        public CreateHeightDto HeightDto { get; set; }    

    }
}
