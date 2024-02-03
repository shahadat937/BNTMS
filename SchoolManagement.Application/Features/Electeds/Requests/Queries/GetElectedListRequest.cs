using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.DTOs.Height; 
using SchoolManagement.Application.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Electeds.Requests.Queries 
{ 
    public class GetElectedListRequest : IRequest<PagedResult<ElectedDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
