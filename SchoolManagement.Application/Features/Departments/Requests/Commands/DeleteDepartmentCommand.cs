using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Departments.Requests.Commands
{
    public class DeleteDepartmentCommand: IRequest
    {
        public int DepartmentId { get; set; }
    }
}
 