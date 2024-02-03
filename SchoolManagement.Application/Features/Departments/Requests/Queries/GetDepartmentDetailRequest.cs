using MediatR;
using SchoolManagement.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Departments.Requests.Queries
{
    public class GetDepartmentDetailRequest: IRequest<DepartmentDto>
    {
        public int DepartmentId { get; set; }
    }
}
 