using MediatR;
using SchoolManagement.Application.DTOs.Department;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Departments.Requests.Queries
{
   public class GetDepartmentListRequest: IRequest<PagedResult<DepartmentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
