using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries
{
   public class GetInterServiceMarkListRequest : IRequest<PagedResult<InterServiceMarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 