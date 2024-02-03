using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Divisions.Requests.Commands
{
    public class DeleteDivisionCommand : IRequest
    {
        public int DivisionId { get; set; }
    }
}
