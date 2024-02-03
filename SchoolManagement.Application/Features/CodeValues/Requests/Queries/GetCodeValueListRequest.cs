using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CodeValues.Requests.Queries 
{ 
    public class GetCodeValueListRequest : IRequest<PagedResult<CodeValueDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
