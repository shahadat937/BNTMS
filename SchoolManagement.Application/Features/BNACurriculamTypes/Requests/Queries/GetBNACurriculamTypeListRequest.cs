using MediatR;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Queries
{
   public class GetBnaCurriculamTypeListRequest : IRequest<PagedResult<BnaCurriculamTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 