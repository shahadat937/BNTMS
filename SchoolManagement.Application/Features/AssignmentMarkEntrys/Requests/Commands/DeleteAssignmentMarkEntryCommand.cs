using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands
{
    public class DeleteAssignmentMarkEntryCommand : IRequest
    {
        public int AssignmentMarkEntryId { get; set; }
    }
}
