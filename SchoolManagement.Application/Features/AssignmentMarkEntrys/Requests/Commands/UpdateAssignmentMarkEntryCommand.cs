using MediatR;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands
{
    public class UpdateAssignmentMarkEntryCommand : IRequest<Unit>
    {
        public AssignmentMarkEntryDto AssignmentMarkEntryDto { get; set; }
    }
}
