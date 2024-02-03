using SchoolManagement.Application.DTOs.Division;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Divisions.Requests.Commands
{
    public class UpdateDivisionCommand : IRequest<Unit>
    {
        public DivisionDto DivisionDto { get; set; }

    }
}
