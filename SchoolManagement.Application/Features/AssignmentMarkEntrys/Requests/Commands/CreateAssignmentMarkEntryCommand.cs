using MediatR;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands
{
    public class CreateAssignmentMarkEntryCommand : IRequest<BaseCommandResponse>
    {
        public CreateAssignmentMarkEntryDto AssignmentMarkEntryDto { get; set; }
    }
}
