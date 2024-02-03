using MediatR;
using SchoolManagement.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Departments.Requests.Commands
{
    public class UpdateDepartmentCommand: IRequest<Unit>
    {
        public DepartmentDto DepartmentDto { get; set; }
    }
}
 