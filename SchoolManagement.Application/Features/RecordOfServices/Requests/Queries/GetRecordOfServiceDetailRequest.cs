using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.RecordOfServices.Requests.Queries
{
    public class GetRecordOfServiceDetailRequest : IRequest<RecordOfServiceDto> 
    {
        public int Id { get; set; } 
    }
}
