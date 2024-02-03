using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System;  
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.RecordOfServices.Requests.Queries 
{ 
    public class GetRecordOfServiceListRequest : IRequest<PagedResult<RecordOfServiceDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
