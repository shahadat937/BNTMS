using MediatR;
using SchoolManagement.Application.DTOs.WeekName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Queries
{
    public class GetWeekNameDetailRequest : IRequest<WeekNameDto>
    {
        public int WeekNameId { get; set; }
    }
}
