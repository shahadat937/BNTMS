using MediatR;
using SchoolManagement.Application.DTOs.Department;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Departments.Requests.Commands
{
    public class CreateDepartmentCommand: IRequest<BaseCommandResponse>
    {
        public CreateDepartmentDto DepartmentDto { get; set; }
    }
}
