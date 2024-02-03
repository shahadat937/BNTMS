using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Queries 
{
    public class GetComplexionsListRequest : IRequest<PagedResult<ComplexionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
