using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Divisions.Requests.Commands
{
    public class CreateDivisionCommand : IRequest<BaseCommandResponse>
    {
        public CreateDivisionDto DivisionDto { get; set; }

    }
}
