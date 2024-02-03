using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.RecordOfService;

namespace SchoolManagement.Application.Features.RecordOfServices.Requests.Commands 
{
    public class CreateRecordOfServiceCommand : IRequest<BaseCommandResponse> 
    {
        public CreateRecordOfServiceDto RecordOfServiceDto { get; set; }      

    }
}
