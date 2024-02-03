using MediatR;
using SchoolManagement.Application.DTOs.BnaSemester;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Queries
{
   public class GetBnaSemesterListRequest: IRequest<PagedResult<BnaSemesterDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
