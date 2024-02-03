using MediatR;
using SchoolManagement.Application.DTOs.Allowance;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Allowances.Requests.Queries
{
    public class GetAllowanceDetailRequest : IRequest<AllowanceDto>
    {
        public int AllowanceId { get; set; }
    }
}
 