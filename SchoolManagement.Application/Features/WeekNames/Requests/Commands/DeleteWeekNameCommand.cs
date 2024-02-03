using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Commands
{
    public class DeleteWeekNameCommand : IRequest
    {
        public int WeekNameId { get; set; }
    }
}
